import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import {  Observable } from "rxjs";

@Injectable()
export class CurrencyService {
    backendUrl: string = "https://localhost:44347"
    constructor(private http:HttpClient) {}

    getList():  Observable<any>{
        return this.http.get(this.backendUrl + '/api/Currency')
    }

    get(id: number):  Observable<any>{
        return this.http.get(this.backendUrl + '/Api/Customer?id='+ id)
    }
    create(customer: any): Observable<any>{
        return this.http.post(this.backendUrl +`/Api/Customer`, customer);

    }
    delete(id: number):  Observable<any>{
        return this.http.delete(this.backendUrl + '/Api/Customer?id='+ id)
    }
}
      