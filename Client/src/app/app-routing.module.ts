import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { KsiazkiComponent } from './ksiazki/ksiazki.component';
import { FormularzComponent } from './formularz/formularz.component';

const routes: Routes = [
  { path: 'ksiazki', component: KsiazkiComponent },
  { path: 'dodawanie', component: FormularzComponent },
  { path: 'ksiazki/:id', component: FormularzComponent },
  { path: '', redirectTo: 'ksiazki', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
