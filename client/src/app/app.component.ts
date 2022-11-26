import { Component,OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IProduct } from './models/product';
import { IPagination } from './models/pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent implements OnInit {  
  title = 'Junk Food';
  products: IProduct[];

  constructor(private http:HttpClient) { }

  ngOnInit(): void {
    this.http.get<any>('https://localhost:7000/api/products?pageSize=50').subscribe(
      (response : IPagination) => {
      this.products=response.data;
     }, error=>{
        console.log(error);
       });
  }
}
