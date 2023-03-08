import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { BranchComponent } from './branch/branch.component';
import { CreateBranchComponent } from './branch/create/create.component';

const routes: Routes = [
  { path: '', component: BranchComponent },
  { path: 'Branches', component: BranchComponent },
  { path: 'Branches/Create', component: CreateBranchComponent },
  // { path: 'Branches/Create/:id', component: CreateProductComponent },
  // { path: 'Branches/Delete/:id', component: DeleteProductComponent },


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
