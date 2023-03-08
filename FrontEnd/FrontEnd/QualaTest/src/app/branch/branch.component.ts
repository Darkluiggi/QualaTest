import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Currency } from '../currency/currency';
import { CurrencyService } from '../currency/currency.service';
import { Branch } from './branch';
import { BranchService } from './branch.service';
import { CreateBranchComponent } from './create/create.component';

@Component({
  selector: 'app-branch',
  templateUrl: './branch.component.html',
  styleUrls: ['./branch.component.css']
})
export class BranchComponent implements OnInit {

  constructor(private branchService: BranchService, private currencyService: CurrencyService, private router:Router, private _dialog: MatDialog) { }
  displayedColumns: string[] = ['id','name', 'description', 'identification', 'created', 'currency', 'actions'];
  dataSource: Branch[] = [];
  branch: Branch = new Branch();
  isNew: Boolean = true;

  ngOnInit(): void {
      this.GetList();
  }

  GetList(){
    this.branchService.getList().subscribe(
      (response: any) => {                  //next() callback
        console.log(response)
        this.dataSource = response.result; 
        console.log(this.dataSource)
      });
  }
  Edit(branch: any){
    this.isNew = false;
    const dialog =  this._dialog.open(CreateBranchComponent,{
      data: {branch: branch, isNew: this.isNew }
    });
  }
  
  Delete(id: any){
    this.branchService.delete(id).subscribe({
      next:(val: any) => {
        alert("Sucursal correctamente eliminada");
        this.GetList();
      },
      error:(val: any) => {
        alert("Ocurrio un error al eliminar la sucursal");
      }
    });
  }
  OpenCreateOrUpdateDialog(){
    this.isNew = true;
    const dialog =  this._dialog.open(CreateBranchComponent,{ data:{isNew:this.isNew}});
    dialog.afterClosed().subscribe((response: boolean)=>{
    if(response){
      this.GetList();
    }
   });
  }
}
