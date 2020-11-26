import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {FormsModule} from '@angular/forms';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {A6AppComponent} from "./assignments/A6/a6-app.component";
import {HeaderComponent} from "./assignments/A6/header/header.component";
import {Recipe} from "./assignments/A6/recipes/recipe-list/recipe.model";
import {ShoppingListComponent} from "./assignments/A6/shopping-list/shopping-list.component";
import {RecipesComponent} from "./assignments/A6/recipes/recipes.component";
import {RecipeItemComponent} from "./assignments/A6/recipes/recipe-list/recipe-item/recipe-item.component";
import {RecipeDetailComponent} from "./assignments/A6/recipes/recipe-detail/recipe-detail.component";
import {RecipeListComponent} from "./assignments/A6/recipes/recipe-list/recipe-list.component";
import {ShoppingEditComponent} from "./assignments/A6/shopping-list/shopping-edit/shopping-edit.component";



@NgModule({
  declarations: [
    AppComponent,
    A6AppComponent,
    HeaderComponent,
    RecipesComponent,
    ShoppingListComponent,
    RecipeItemComponent,
    RecipeDetailComponent,
    RecipeListComponent,
    ShoppingEditComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
