import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { InventoryService } from '../../../services/inventory.service';
import { Inventory } from '../../../models/inventory';
import {URLConstant} from '../../../services/api-constant'


@Component({
  selector: 'app-inventory',
  templateUrl: './inventory.component.html',
  styleUrls: ['./inventory.component.css']
})
export class InventoryComponent implements OnInit {

  dataSaved = false;
  inventoryForm: any;
  allInventory: Observable<Inventory[]>;
  inventoryIdUpdate = null;
  massage = null;
  imageUrlPrefix=URLConstant.apiUrl+"/upload/";
  imageFileName:String='';
  constructor(private formbulider: FormBuilder, private inventoryService: InventoryService) { }

  ngOnInit() {
    this.inventoryForm = this.formbulider.group({
      name: ['', [Validators.required]],
      description: ['', [Validators.required]],
      price: ['', [Validators.required]],
      imageUrl: ['', [Validators.required]]
    });
    this.loadAllInventory();
  }

  loadAllInventory() {
    this.allInventory = this.inventoryService.getAllInventory();
  }

  loadInventoryToEdit(inventoryId: Number) {
    this.inventoryService.geInventoryById(inventoryId).subscribe(inventory => {
      this.massage = null;
      this.dataSaved = false;
      this.inventoryIdUpdate = inventory.id;
      this.inventoryForm.controls['name'].setValue(inventory.name);
      this.inventoryForm.controls['description'].setValue(inventory.description);
      this.inventoryForm.controls['price'].setValue(inventory.price);
      this.inventoryForm.controls['imageUrl'].setValue(inventory.imageUrl);
      this.imageFileName=inventory.imageUrl;
    });

  }

  CreateInventory(inventory: Inventory) {
    if (this.inventoryIdUpdate == null) {
      this.inventoryService.createInventory(inventory).subscribe(
        () => {
          this.dataSaved = true;
          this.massage = 'Record saved Successfully';
          this.loadAllInventory();
          this.inventoryIdUpdate = null;
          this.inventoryForm.reset();
        }
      );
    } else {
      inventory.id = this.inventoryIdUpdate;
      this.inventoryService.updateInventory(inventory).subscribe(() => {
        this.dataSaved = true;
        this.massage = 'Record Updated Successfully';
        this.loadAllInventory();
        this.inventoryIdUpdate = null;
        this.inventoryForm.reset();
        this.imageFileName='';
      });
    }
  }

  deleteInventory(inventoryId: Number) {
    if (confirm("Are you sure you want to delete this ?")) {
      this.inventoryService.deleteInventoryById(inventoryId).subscribe(() => {
        this.dataSaved = true;
        this.massage = 'Record Deleted Succefully';
        this.loadAllInventory();
        this.inventoryIdUpdate = null;
        this.inventoryForm.reset();

      });
    }
  }

  onFileChange(files){
    if (files.length === 0)
      return;
    const formData = new FormData();
    for (let file of files)
      formData.append(file.name, file);
      this.inventoryService.uploadImage(formData).subscribe(res => {
        this.imageFileName=res.fileName;
        this.inventoryForm.controls['imageUrl'].setValue(res.fileName);
      })
  }
  
  resetForm() {
    this.inventoryForm.reset();
    this.massage = null;
    this.dataSaved = false;
  }
  onFormSubmit() {  
    this.dataSaved = false;  
    const employee = this.inventoryForm.value;  
    this.CreateInventory(employee);  
    this.inventoryForm.reset();  
  }  

}
