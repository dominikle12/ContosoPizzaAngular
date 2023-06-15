import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public orders?: Order[];

  constructor(http: HttpClient) {
    http.get<Order[]>('/order').subscribe(result => {
      console.log(result)
      this.orders = result;
    }, error => console.error(error));
  }

  title = 'angularapp';

}

interface Order {
  id: number,
  pizzas: object[],
  price: number,
  card: boolean,
  distance: string,
  prefferedCar: object 
}
