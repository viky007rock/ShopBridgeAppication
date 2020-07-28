import { Injectable } from '@angular/core';  
import { HttpClient } from '@angular/common/http';  
import { HttpHeaders } from '@angular/common/http';  
import { Observable } from 'rxjs';  
import { Inventory } from '../models/inventory';  
import { ImageResult } from '../models/imageResult';  
import { URLConstant,ApiConstant } from './api-constant';  

@Injectable({
  providedIn: 'root'
})
export class InventoryService {

  constructor(private http: HttpClient) { }
  getAllInventory(): Observable<Inventory[]> {  
    return this.http.get<Inventory[]>(URLConstant.apiUrl+"/"+ApiConstant.inventoryOperation);  
  }  
  geInventoryById(id: Number): Observable<Inventory> {  
    return this.http.get<Inventory>(URLConstant.apiUrl+"/"+ApiConstant.inventoryOperation+"/"+ id);  
  }  
  createInventory(inventory: Inventory): Observable<Boolean> {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    return this.http.post<Boolean>(URLConstant.apiUrl+"/"+ApiConstant.inventoryOperation,  
    inventory, httpOptions);  
  }  
  updateInventory(inventory: Inventory): Observable<Boolean> {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    return this.http.post<Boolean>(URLConstant.apiUrl+"/"+ApiConstant.inventoryOperation+"/"+inventory.id,  
    inventory, httpOptions);  
  }  
  deleteInventoryById(id: Number): Observable<Boolean> {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    return this.http.delete<Boolean>(URLConstant.apiUrl+"/"+ApiConstant.inventoryOperation+"/" +id,  
 httpOptions);  
  }  

  uploadImage(file:FormData):Observable<ImageResult>{
    // const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    return this.http.post<ImageResult>(URLConstant.apiUrl+"/"+ApiConstant.inventoryOperation+"/file/upload",file);  
  }

}
