import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';


@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html'
})
export class BasketComponent implements OnInit {
  public items: BasketItem[];
  private baseUrl: string;
  private http: HttpClient;

  constructor(http: HttpClient, @Inject('BASE_API_URL') baseUrl: string) {
    this.items = [];
    this.http = http;
    this.baseUrl = baseUrl;
  }

  ngOnInit() {
  }

  remove(basketItem: BasketItem) {
    for (var i: number = 0; i < this.items.length; i++) {
      if (this.items[i].productId == basketItem.productId) {
        this.items.splice(i, 1);
        break;
      }
    }
  }

  addBasketItem(product) {
    var newItemDTO = {
      productId: product.id,
      productName: product.name,
      unitPrice: product.price,
      quantity: 1,
      totalPrice: product.price,
      promotionId: product.promotionId,
      promotionName: product.promotionName
    };

    var postContent = {
      basket: {
        customerId: -1,
        customerName: '',
        items: this.items
      },
      newItem: newItemDTO
    };
    console.log(newItemDTO);

    this.http.post<any>(this.baseUrl + 'basket', postContent)
      .subscribe(result => {
        console.log(result);
        console.log(result.items);
        this.items = result.items;
      },
        error => console.error(error));
  }

}

interface BasketItem {
  productId: number;
  productName: string;
  unitPrice: number;
  quantity: number;
  totalPrice: number;
  promotionId: number;
  promotionName: string;
}
