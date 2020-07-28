import { NgModule, ModuleWithProviders  } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InventoryComponent } from './inventory/inventory.component';
import { InventoryService } from '../../services/inventory.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {
  MatButtonModule, MatMenuModule, MatDatepickerModule, MatNativeDateModule, MatIconModule, MatCardModule, MatSidenavModule, MatFormFieldModule,
  MatInputModule, MatTooltipModule, MatToolbarModule
} from '@angular/material';
import { MatRadioModule } from '@angular/material/radio';
import {inventoryRouting} from './inventory-routing.module';


@NgModule({
  declarations: [InventoryComponent],
  imports: [
    inventoryRouting,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatMenuModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatIconModule,
    MatRadioModule,
    MatCardModule,
    MatSidenavModule,
    MatInputModule,
    MatTooltipModule,
    MatToolbarModule,
  ]
})
export class InventoryModule {
  static forRoot(): ModuleWithProviders {
    return {
      ngModule: InventoryModule,
      providers:[ InventoryService]
    };
  }
 }
