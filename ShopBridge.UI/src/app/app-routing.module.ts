import { NgModule,ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    children: [ 
      { path: '',loadChildren: './inventory/inventory.module#InventoryModule' }
    ]
  },
  
];

// @NgModule({
//   imports: [RouterModule.forRoot(routes)],
//   exports: [RouterModule]
// })
export const routing: ModuleWithProviders = RouterModule.forRoot(routes, { useHash: true });
