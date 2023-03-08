import { Component, OnInit } from '@angular/core';
import { Currency } from './currency';
import { CurrencyService } from './currency.service';

@Component({
  selector: 'app-currency',
  templateUrl: './currency.component.html',
  styleUrls: ['./currency.component.css']
})
export class CurrencyComponent implements OnInit {

  currencies: Currency[] = [];
  constructor(private currencyService: CurrencyService) { }

  ngOnInit(): void {    
    this.currencyService.getList().subscribe(
      (response: any) =>{
        console.log(response)
        this.currencies = response.result; 
        console.log(this.currencies)
      }
    );
  }

}
