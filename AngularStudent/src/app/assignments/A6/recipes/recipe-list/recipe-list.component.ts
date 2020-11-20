import {Component, OnInit} from '@angular/core';
import {Recipe} from "./recipe.model";

@Component({
  selector: 'app-recipe-list',
  templateUrl: './recipe-list.component.html',
  styleUrls: ['./recipe-list.component.scss']
})
export class RecipeListComponent implements OnInit {
  recipes: Recipe[] = [];

  constructor() {
    this.recipes.push(
      new Recipe(
        't1',
        'd1',
        'https://via.placeholder.com/50x50'),
      new Recipe(
        't2',
        'd2',
        'https://via.placeholder.com/50x50')
    );
  }

  ngOnInit(): void {
  }

}
