import { ModuleWithProviders } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InventoryComponent } from './inventory/inventory.component';

const routes: Routes = [
    { path: '', redirectTo: 'inventory', pathMatch: 'full' },
    { path: 'inventory', component: InventoryComponent, data: { title: 'Inventory' } },

]
export const inventoryRouting: ModuleWithProviders = RouterModule.forChild(routes);