import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  public nomeUser = 'Eric Figueiredo';
  public imageUser = 'https://upload.wikimedia.org/wikipedia/commons/thumb/a/a0/Reuni%C3%A3o_com_o_ator_norte-americano_Keanu_Reeves_%28cropped%29.jpg/256px-Reuni%C3%A3o_com_o_ator_norte-americano_Keanu_Reeves_%28cropped%29.jpg';
  constructor() { }

  ngOnInit(): void {
  }

}
