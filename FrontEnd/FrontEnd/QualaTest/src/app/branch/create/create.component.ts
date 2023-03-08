import { Component, Inject, OnInit } from '@angular/core';
import { Currency } from 'src/app/currency/currency';
import { CurrencyService } from 'src/app/currency/currency.service';
import {FormControl,FormGroup, Validators} from '@angular/forms';
import { Branch } from '../branch';
import { BranchService } from '../branch.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { inject } from '@angular/core/testing';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateBranchComponent implements OnInit {

  date = new FormControl(new Date());
  serializedDate = new FormControl(new Date().toISOString());
  currencies: Currency[] = [];
  minDate: Date = new Date();
  required = new FormControl('', [Validators.required]);
  branchForm: any;
  branch: Branch = new Branch();
  isNew!: Boolean;

  constructor(private currencyService: CurrencyService, 
    private branchService: BranchService, 
    private _dialog: MatDialogRef<CreateBranchComponent>,
    @Inject(MAT_DIALOG_DATA) private data: any) { }

  ngOnInit(): void {  
    debugger
    this.isNew = this.data.isNew; 
    this.currencyService.getList().subscribe(
      (response: any) =>{
        console.log(response)
        this.currencies = response.result; 
        console.log(this.currencies)
      }      
    );
    this.branchForm = new FormGroup({
      id: new FormControl(this.branch.Id),
      code: new FormControl(this.branch.Code, [
        Validators.required
      ]),
      description: new FormControl(this.branch.Description, 
      [
          Validators.required, 
          Validators.maxLength(250)
      ]),
      address: new FormControl(this.branch.Address, [
        Validators.required, 
        Validators.maxLength(250)
      ]),
      identification: new FormControl(this.branch.Identification, [
        Validators.required, 
        Validators.maxLength(50)
      ]),
      createdTime: new FormControl(this.branch.CreatedTime, Validators.required),
      currencyId: new FormControl(this.branch.CurrencyId, Validators.required)      
    });
    console.log(this.data);
    this.branchForm.patchValue(this.data.branch);
  }
  

  get code() { return this.branchForm.get('code'); }
  get description() { return this.branchForm.get('description'); }
  get address() { return this.branchForm.get('address'); }  
  get identification() { return this.branchForm.get('identification'); }
  get createdTime() { return this.branchForm.get('createdTime'); }  
  get currencyId() { return this.branchForm.get('currency'); }

  Save(){
    if(this.branchForm.valid){
      console.log(this.branchForm.value);
      this.branchService.createOrUpdate(this.branchForm.value).subscribe({

        next:(val: any) => {
          alert('Sucursal guardada correctamente');
          this._dialog.close(true);
        },
        error:(val: any) => {
          alert('Ocurrió un error al guardar la sucursal');
          this._dialog.close(true);
        }
      }
      );
    }
  }
}
