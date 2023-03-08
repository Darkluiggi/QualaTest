import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import {  Observable } from "rxjs";

@Injectable()
export class BranchService {
    backendUrl: string = "https://localhost:44347"
    constructor(private http:HttpClient) {}

    getList():  Observable<any>{
        return this.http.get(this.backendUrl + '/api/Branch')
    }

    get(id: number):  Observable<any>{
        return this.http.get(this.backendUrl + '/Api/Branch/'+ id)
    }
    createOrUpdate(branch: any): Observable<any>{
        return this.http.post(this.backendUrl +`/Api/Branch`, branch);

    }
    delete(id: string):  Observable<any>{
        return this.http.delete(this.backendUrl +`/Api/Branch`, {body:{id}})
    }
}
      