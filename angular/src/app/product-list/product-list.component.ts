import { Component, EventEmitter, Inject, OnInit, Output } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html'
})
export class ProductListComponent implements OnInit {
  public products: Product[];
  @Output() addButtonClicked: EventEmitter<Product> = new EventEmitter();

  constructor(http: HttpClient, @Inject('BASE_API_URL') baseUrl: string) {
    http.get<Product[]>(baseUrl + 'products').subscribe(result => {
      this.products = result;
    }, error => console.error(error));
  }

  ngOnInit(): void {
  }

  add(product: Product) {
    this.addButtonClicked.emit(product);
  }

}

interface Product {
  id: number;
  name: string;
  price: number;
  promotionId: number;
  promotionName: string;
}
