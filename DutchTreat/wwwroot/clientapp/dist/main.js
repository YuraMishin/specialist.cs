(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["main"],{

/***/ 0:
/*!*********************************!*\
  !*** multi ./ClientApp/main.ts ***!
  \*********************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__(/*! D:\IT\csharp\projects\specialist.cs\DutchTreat\ClientApp\main.ts */"QqbR");


/***/ }),

/***/ "1BNF":
/*!*****************************************************!*\
  !*** ./ClientApp/app/shop/productList.component.ts ***!
  \*****************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
exports.ProductList = void 0;
var core_1 = __webpack_require__(/*! @angular/core */ "fXoL");
var i0 = __webpack_require__(/*! @angular/core */ "fXoL");
var i1 = __webpack_require__(/*! ../shared/dataService */ "g4ZZ");
var i2 = __webpack_require__(/*! @angular/common */ "ofXK");
function ProductList_div_1_Template(rf, ctx) { if (rf & 1) {
    var _r3 = i0.ɵɵgetCurrentView();
    i0.ɵɵelementStart(0, "div", 2);
    i0.ɵɵelementStart(1, "div", 3);
    i0.ɵɵelement(2, "img", 4);
    i0.ɵɵelementStart(3, "h3");
    i0.ɵɵtext(4);
    i0.ɵɵelementEnd();
    i0.ɵɵelementStart(5, "ul", 5);
    i0.ɵɵelementStart(6, "li");
    i0.ɵɵelementStart(7, "strong");
    i0.ɵɵtext(8, "Price");
    i0.ɵɵelementEnd();
    i0.ɵɵtext(9);
    i0.ɵɵpipe(10, "currency");
    i0.ɵɵelementEnd();
    i0.ɵɵelementStart(11, "li");
    i0.ɵɵelementStart(12, "strong");
    i0.ɵɵtext(13, "Artist");
    i0.ɵɵelementEnd();
    i0.ɵɵtext(14);
    i0.ɵɵelementEnd();
    i0.ɵɵelementStart(15, "li");
    i0.ɵɵelementStart(16, "strong");
    i0.ɵɵtext(17, "Title");
    i0.ɵɵelementEnd();
    i0.ɵɵtext(18);
    i0.ɵɵelementEnd();
    i0.ɵɵelementStart(19, "li");
    i0.ɵɵelementStart(20, "strong");
    i0.ɵɵtext(21, "Description");
    i0.ɵɵelementEnd();
    i0.ɵɵtext(22);
    i0.ɵɵelementEnd();
    i0.ɵɵelementEnd();
    i0.ɵɵelementStart(23, "button", 6);
    i0.ɵɵlistener("click", function ProductList_div_1_Template_button_click_23_listener() { i0.ɵɵrestoreView(_r3); var p_r1 = ctx.$implicit; var ctx_r2 = i0.ɵɵnextContext(); return ctx_r2.addProduct(p_r1); });
    i0.ɵɵtext(24, " Buy ");
    i0.ɵɵelementEnd();
    i0.ɵɵelementEnd();
    i0.ɵɵelementEnd();
} if (rf & 2) {
    var p_r1 = ctx.$implicit;
    i0.ɵɵadvance(2);
    i0.ɵɵpropertyInterpolate1("src", "/img/", p_r1.artId, ".jpg", i0.ɵɵsanitizeUrl);
    i0.ɵɵproperty("alt", p_r1.title);
    i0.ɵɵadvance(2);
    i0.ɵɵtextInterpolate2("", p_r1.category, " - ", p_r1.size, "");
    i0.ɵɵadvance(5);
    i0.ɵɵtextInterpolate1(": ", i0.ɵɵpipeBind3(10, 8, p_r1.price, "USD", "symbol"), "");
    i0.ɵɵadvance(5);
    i0.ɵɵtextInterpolate1(": ", p_r1.artist, "");
    i0.ɵɵadvance(4);
    i0.ɵɵtextInterpolate1(": ", p_r1.title, "");
    i0.ɵɵadvance(4);
    i0.ɵɵtextInterpolate1(": ", p_r1.artDescription, "");
} }
var ProductList = /** @class */ (function () {
    function ProductList(data) {
        this.data = data;
    }
    ProductList.prototype.ngOnInit = function () {
        var _this = this;
        this.data.loadProducts()
            .subscribe(function (success) {
            if (success) {
                _this.products = _this.data.products;
            }
        });
    };
    ProductList.prototype.addProduct = function (product) {
        this.data.addToOrder(product);
    };
    ProductList.ɵfac = function ProductList_Factory(t) { return new (t || ProductList)(i0.ɵɵdirectiveInject(i1.DataService)); };
    ProductList.ɵcmp = i0.ɵɵdefineComponent({ type: ProductList, selectors: [["product-list"]], decls: 2, vars: 1, consts: [[1, "row"], ["class", "product-info col-md-4", 4, "ngFor", "ngForOf"], [1, "product-info", "col-md-4"], [1, "card", "bg-light", "p-1", "m-1"], [1, "img-fluid", 3, "src", "alt"], [1, "product-props", "list-unstyled"], ["id", "buyButton", 1, "btn", "btn-success", 3, "click"]], template: function ProductList_Template(rf, ctx) { if (rf & 1) {
            i0.ɵɵelementStart(0, "div", 0);
            i0.ɵɵtemplate(1, ProductList_div_1_Template, 25, 12, "div", 1);
            i0.ɵɵelementEnd();
        } if (rf & 2) {
            i0.ɵɵadvance(1);
            i0.ɵɵproperty("ngForOf", ctx.products);
        } }, directives: [i2.NgForOf], pipes: [i2.CurrencyPipe], styles: [".product-info[_ngcontent-%COMP%]   img[_ngcontent-%COMP%] {\r\n  max-width: 100px;\r\n  float: left;\r\n  margin: 0 2px;\r\n  border: solid 1px black;\r\n}\r\n\r\n.product-info[_ngcontent-%COMP%]   .product-name[_ngcontent-%COMP%] {\r\n  font-size: large;\r\n  font-weight: bold;\r\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIkNsaWVudEFwcC9hcHAvc2hvcC9wcm9kdWN0TGlzdC5jb21wb25lbnQuY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0VBQ0UsZ0JBQWdCO0VBQ2hCLFdBQVc7RUFDWCxhQUFhO0VBQ2IsdUJBQXVCO0FBQ3pCOztBQUVBO0VBQ0UsZ0JBQWdCO0VBQ2hCLGlCQUFpQjtBQUNuQiIsImZpbGUiOiJDbGllbnRBcHAvYXBwL3Nob3AvcHJvZHVjdExpc3QuY29tcG9uZW50LmNzcyIsInNvdXJjZXNDb250ZW50IjpbIi5wcm9kdWN0LWluZm8gaW1nIHtcclxuICBtYXgtd2lkdGg6IDEwMHB4O1xyXG4gIGZsb2F0OiBsZWZ0O1xyXG4gIG1hcmdpbjogMCAycHg7XHJcbiAgYm9yZGVyOiBzb2xpZCAxcHggYmxhY2s7XHJcbn1cclxuXHJcbi5wcm9kdWN0LWluZm8gLnByb2R1Y3QtbmFtZSB7XHJcbiAgZm9udC1zaXplOiBsYXJnZTtcclxuICBmb250LXdlaWdodDogYm9sZDtcclxufVxyXG5cclxuIl19 */"] });
    return ProductList;
}());
exports.ProductList = ProductList;
/*@__PURE__*/ (function () { i0.ɵsetClassMetadata(ProductList, [{
        type: core_1.Component,
        args: [{
                selector: "product-list",
                templateUrl: "productList.component.html",
                styleUrls: ["productList.component.css"]
            }]
    }], function () { return [{ type: i1.DataService }]; }, null); })();


/***/ }),

/***/ "Bj0p":
/*!******************************************************!*\
  !*** ./ClientApp/app/checkout/checkout.component.ts ***!
  \******************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
exports.Checkout = void 0;
var core_1 = __webpack_require__(/*! @angular/core */ "fXoL");
var i0 = __webpack_require__(/*! @angular/core */ "fXoL");
var i1 = __webpack_require__(/*! ../shared/dataService */ "g4ZZ");
var i2 = __webpack_require__(/*! @angular/router */ "tyNb");
var i3 = __webpack_require__(/*! @angular/common */ "ofXK");
function Checkout_div_1_Template(rf, ctx) { if (rf & 1) {
    i0.ɵɵelementStart(0, "div", 9);
    i0.ɵɵtext(1);
    i0.ɵɵelementEnd();
} if (rf & 2) {
    var ctx_r0 = i0.ɵɵnextContext();
    i0.ɵɵadvance(1);
    i0.ɵɵtextInterpolate(ctx_r0.errorMessage);
} }
function Checkout_tr_5_Template(rf, ctx) { if (rf & 1) {
    i0.ɵɵelementStart(0, "tr");
    i0.ɵɵelementStart(1, "td");
    i0.ɵɵelement(2, "img", 10);
    i0.ɵɵelementEnd();
    i0.ɵɵelementStart(3, "td");
    i0.ɵɵtext(4);
    i0.ɵɵelementEnd();
    i0.ɵɵelementStart(5, "td");
    i0.ɵɵtext(6);
    i0.ɵɵelementEnd();
    i0.ɵɵelementStart(7, "td");
    i0.ɵɵtext(8);
    i0.ɵɵpipe(9, "currency");
    i0.ɵɵelementEnd();
    i0.ɵɵelementStart(10, "td");
    i0.ɵɵtext(11);
    i0.ɵɵpipe(12, "currency");
    i0.ɵɵelementEnd();
    i0.ɵɵelementEnd();
} if (rf & 2) {
    var o_r2 = ctx.$implicit;
    i0.ɵɵadvance(2);
    i0.ɵɵpropertyInterpolate1("src", "/img/", o_r2.productArtId, ".jpg", i0.ɵɵsanitizeUrl);
    i0.ɵɵadvance(2);
    i0.ɵɵtextInterpolate4("", o_r2.productCategory, "(", o_r2.productSize, ") - ", o_r2.productArtist, ": ", o_r2.productTitle, "");
    i0.ɵɵadvance(2);
    i0.ɵɵtextInterpolate(o_r2.quantity);
    i0.ɵɵadvance(2);
    i0.ɵɵtextInterpolate(i0.ɵɵpipeBind3(9, 8, o_r2.unitPrice, "USD", "symbol"));
    i0.ɵɵadvance(3);
    i0.ɵɵtextInterpolate(i0.ɵɵpipeBind3(12, 12, o_r2.unitPrice * o_r2.quantity, "USD", "symbol"));
} }
var Checkout = /** @class */ (function () {
    function Checkout(data, router) {
        this.data = data;
        this.router = router;
        this.errorMessage = "";
    }
    Checkout.prototype.onCheckout = function () {
        var _this = this;
        this.data.checkout()
            .subscribe(function (success) {
            if (success) {
                _this.router.navigate(["/"]);
            }
        }, function (err) { return _this.errorMessage = "Failed to save order"; });
    };
    Checkout.ɵfac = function Checkout_Factory(t) { return new (t || Checkout)(i0.ɵɵdirectiveInject(i1.DataService), i0.ɵɵdirectiveInject(i2.Router)); };
    Checkout.ɵcmp = i0.ɵɵdefineComponent({ type: Checkout, selectors: [["checkout"]], decls: 29, vars: 12, consts: [[1, "row"], ["class", "alert alert-warning", 4, "ngIf"], [1, "table", "table-bordered", "table-hover"], [4, "ngFor", "ngForOf"], [1, "col-md-4", "col-md-offset-8", "text-right"], [1, "table", "table-condensed"], [1, "text-right"], [1, "btn", "btn-success", 3, "click"], ["routerLink", "/", 1, "btn", "btn-info"], [1, "alert", "alert-warning"], ["alt", "o.productTitle", 1, "img-thumbnail", "checkout-thumb", 3, "src"]], template: function Checkout_Template(rf, ctx) { if (rf & 1) {
            i0.ɵɵelementStart(0, "div", 0);
            i0.ɵɵtemplate(1, Checkout_div_1_Template, 2, 1, "div", 1);
            i0.ɵɵelementStart(2, "h3");
            i0.ɵɵtext(3, "Confirm Order");
            i0.ɵɵelementEnd();
            i0.ɵɵelementStart(4, "table", 2);
            i0.ɵɵtemplate(5, Checkout_tr_5_Template, 13, 16, "tr", 3);
            i0.ɵɵelementEnd();
            i0.ɵɵelementStart(6, "div", 4);
            i0.ɵɵelementStart(7, "table", 5);
            i0.ɵɵelementStart(8, "tr");
            i0.ɵɵelementStart(9, "td", 6);
            i0.ɵɵtext(10, "Subtotal");
            i0.ɵɵelementEnd();
            i0.ɵɵelementStart(11, "td", 6);
            i0.ɵɵtext(12);
            i0.ɵɵpipe(13, "currency");
            i0.ɵɵelementEnd();
            i0.ɵɵelementEnd();
            i0.ɵɵelementStart(14, "tr");
            i0.ɵɵelementStart(15, "td", 6);
            i0.ɵɵtext(16, "Shipping");
            i0.ɵɵelementEnd();
            i0.ɵɵelementStart(17, "td", 6);
            i0.ɵɵtext(18, "$ 0.00");
            i0.ɵɵelementEnd();
            i0.ɵɵelementEnd();
            i0.ɵɵelementStart(19, "tr");
            i0.ɵɵelementStart(20, "td", 6);
            i0.ɵɵtext(21, "Total:");
            i0.ɵɵelementEnd();
            i0.ɵɵelementStart(22, "td", 6);
            i0.ɵɵtext(23);
            i0.ɵɵpipe(24, "currency");
            i0.ɵɵelementEnd();
            i0.ɵɵelementEnd();
            i0.ɵɵelementEnd();
            i0.ɵɵelementStart(25, "button", 7);
            i0.ɵɵlistener("click", function Checkout_Template_button_click_25_listener() { return ctx.onCheckout(); });
            i0.ɵɵtext(26, "Complete Purchase");
            i0.ɵɵelementEnd();
            i0.ɵɵelementStart(27, "a", 8);
            i0.ɵɵtext(28, "Cancel");
            i0.ɵɵelementEnd();
            i0.ɵɵelementEnd();
            i0.ɵɵelementEnd();
        } if (rf & 2) {
            i0.ɵɵadvance(1);
            i0.ɵɵproperty("ngIf", ctx.errorMessage);
            i0.ɵɵadvance(4);
            i0.ɵɵproperty("ngForOf", ctx.data.order.items);
            i0.ɵɵadvance(7);
            i0.ɵɵtextInterpolate(i0.ɵɵpipeBind3(13, 4, ctx.data.order.subtotal, "USD", "symbol"));
            i0.ɵɵadvance(11);
            i0.ɵɵtextInterpolate(i0.ɵɵpipeBind3(24, 8, ctx.data.order.subtotal, "USD", "symbol"));
        } }, directives: [i3.NgIf, i3.NgForOf, i2.RouterLinkWithHref], pipes: [i3.CurrencyPipe], styles: [".checkout-thumb[_ngcontent-%COMP%] {\r\n  max-width: 100px;\r\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIkNsaWVudEFwcC9hcHAvY2hlY2tvdXQvY2hlY2tvdXQuY29tcG9uZW50LmNzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQTtFQUNFLGdCQUFnQjtBQUNsQiIsImZpbGUiOiJDbGllbnRBcHAvYXBwL2NoZWNrb3V0L2NoZWNrb3V0LmNvbXBvbmVudC5jc3MiLCJzb3VyY2VzQ29udGVudCI6WyIuY2hlY2tvdXQtdGh1bWIge1xyXG4gIG1heC13aWR0aDogMTAwcHg7XHJcbn1cclxuIl19 */"] });
    return Checkout;
}());
exports.Checkout = Checkout;
/*@__PURE__*/ (function () { i0.ɵsetClassMetadata(Checkout, [{
        type: core_1.Component,
        args: [{
                selector: "checkout",
                templateUrl: "checkout.component.html",
                styleUrls: ['checkout.component.css']
            }]
    }], function () { return [{ type: i1.DataService }, { type: i2.Router }]; }, null); })();


/***/ }),

/***/ "FhR5":
/*!***********************************************!*\
  !*** ./ClientApp/environments/environment.ts ***!
  \***********************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.
Object.defineProperty(exports, "__esModule", { value: true });
exports.environment = void 0;
exports.environment = {
    production: false
};
/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.


/***/ }),

/***/ "HJlE":
/*!****************************************!*\
  !*** ./ClientApp/app/app.component.ts ***!
  \****************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
exports.AppComponent = void 0;
var core_1 = __webpack_require__(/*! @angular/core */ "fXoL");
var i0 = __webpack_require__(/*! @angular/core */ "fXoL");
var i1 = __webpack_require__(/*! @angular/router */ "tyNb");
var AppComponent = /** @class */ (function () {
    function AppComponent() {
        this.title = 'Product List';
    }
    AppComponent.ɵfac = function AppComponent_Factory(t) { return new (t || AppComponent)(); };
    AppComponent.ɵcmp = i0.ɵɵdefineComponent({ type: AppComponent, selectors: [["my-app"]], decls: 1, vars: 0, template: function AppComponent_Template(rf, ctx) { if (rf & 1) {
            i0.ɵɵelement(0, "router-outlet");
        } }, directives: [i1.RouterOutlet], encapsulation: 2 });
    return AppComponent;
}());
exports.AppComponent = AppComponent;
/*@__PURE__*/ (function () { i0.ɵsetClassMetadata(AppComponent, [{
        type: core_1.Component,
        args: [{
                selector: 'my-app',
                templateUrl: "./app.component.html",
                styles: []
            }]
    }], null, null); })();


/***/ }),

/***/ "J4hL":
/*!*************************************!*\
  !*** ./ClientApp/app/app.module.ts ***!
  \*************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
exports.AppModule = void 0;
var platform_browser_1 = __webpack_require__(/*! @angular/platform-browser */ "jhN1");
var core_1 = __webpack_require__(/*! @angular/core */ "fXoL");
var http_1 = __webpack_require__(/*! @angular/common/http */ "tk/3");
var app_component_1 = __webpack_require__(/*! ./app.component */ "HJlE");
var productList_component_1 = __webpack_require__(/*! ./shop/productList.component */ "1BNF");
var cart_component_1 = __webpack_require__(/*! ./shop/cart.component */ "lTML");
var shop_component_1 = __webpack_require__(/*! ./shop/shop.component */ "TAhd");
var checkout_component_1 = __webpack_require__(/*! ./checkout/checkout.component */ "Bj0p");
var login_component_1 = __webpack_require__(/*! ./login/login.component */ "fbMm");
var dataService_1 = __webpack_require__(/*! ./shared/dataService */ "g4ZZ");
var router_1 = __webpack_require__(/*! @angular/router */ "tyNb");
var forms_1 = __webpack_require__(/*! @angular/forms */ "3Pt+");
var i0 = __webpack_require__(/*! @angular/core */ "fXoL");
var i1 = __webpack_require__(/*! @angular/router */ "tyNb");
var routes = [
    { path: "", component: shop_component_1.Shop },
    { path: "checkout", component: checkout_component_1.Checkout },
    { path: "login", component: login_component_1.Login }
];
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule.ɵmod = i0.ɵɵdefineNgModule({ type: AppModule, bootstrap: [app_component_1.AppComponent] });
    AppModule.ɵinj = i0.ɵɵdefineInjector({ factory: function AppModule_Factory(t) { return new (t || AppModule)(); }, providers: [
            dataService_1.DataService
        ], imports: [[
                platform_browser_1.BrowserModule,
                http_1.HttpClientModule,
                forms_1.FormsModule,
                router_1.RouterModule.forRoot(routes, {
                    useHash: true,
                    enableTracing: false // for Debugging of the Routes
                })
            ]] });
    return AppModule;
}());
exports.AppModule = AppModule;
(function () { (typeof ngJitMode === "undefined" || ngJitMode) && i0.ɵɵsetNgModuleScope(AppModule, { declarations: [app_component_1.AppComponent,
        productList_component_1.ProductList,
        cart_component_1.Cart,
        shop_component_1.Shop,
        checkout_component_1.Checkout,
        login_component_1.Login], imports: [platform_browser_1.BrowserModule,
        http_1.HttpClientModule,
        forms_1.FormsModule, i1.RouterModule] }); })();
/*@__PURE__*/ (function () { i0.ɵsetClassMetadata(AppModule, [{
        type: core_1.NgModule,
        args: [{
                declarations: [
                    app_component_1.AppComponent,
                    productList_component_1.ProductList,
                    cart_component_1.Cart,
                    shop_component_1.Shop,
                    checkout_component_1.Checkout,
                    login_component_1.Login
                ],
                imports: [
                    platform_browser_1.BrowserModule,
                    http_1.HttpClientModule,
                    forms_1.FormsModule,
                    router_1.RouterModule.forRoot(routes, {
                        useHash: true,
                        enableTracing: false // for Debugging of the Routes
                    })
                ],
                providers: [
                    dataService_1.DataService
                ],
                bootstrap: [app_component_1.AppComponent]
            }]
    }], null, null); })();


/***/ }),

/***/ "JqFU":
/*!***************************************!*\
  !*** ./ClientApp/app/shared/order.ts ***!
  \***************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
exports.OrderItem = exports.Order = void 0;
var _ = __webpack_require__(/*! lodash */ "LvDl");
var Order = /** @class */ (function () {
    function Order() {
        this.orderDate = new Date();
        this.items = new Array();
    }
    Object.defineProperty(Order.prototype, "subtotal", {
        get: function () {
            return _.sum(_.map(this.items, function (i) { return i.unitPrice * i.quantity; }));
        },
        enumerable: false,
        configurable: true
    });
    ;
    return Order;
}());
exports.Order = Order;
var OrderItem = /** @class */ (function () {
    function OrderItem() {
    }
    return OrderItem;
}());
exports.OrderItem = OrderItem;


/***/ }),

/***/ "QqbR":
/*!***************************!*\
  !*** ./ClientApp/main.ts ***!
  \***************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__(/*! @angular/core */ "fXoL");
var environment_1 = __webpack_require__(/*! ./environments/environment */ "FhR5");
var __NgCli_bootstrap_1 = __webpack_require__(/*! ./app/app.module */ "J4hL");
var __NgCli_bootstrap_2 = __webpack_require__(/*! @angular/platform-browser */ "jhN1");
if (environment_1.environment.production) {
    core_1.enableProdMode();
}
__NgCli_bootstrap_2.platformBrowser().bootstrapModule(__NgCli_bootstrap_1.AppModule)
    .catch(function (err) { return console.error(err); });


/***/ }),

/***/ "TAhd":
/*!**********************************************!*\
  !*** ./ClientApp/app/shop/shop.component.ts ***!
  \**********************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
exports.Shop = void 0;
var core_1 = __webpack_require__(/*! @angular/core */ "fXoL");
var i0 = __webpack_require__(/*! @angular/core */ "fXoL");
var i1 = __webpack_require__(/*! ./productList.component */ "1BNF");
var i2 = __webpack_require__(/*! ./cart.component */ "lTML");
var Shop = /** @class */ (function () {
    function Shop() {
        this.title = 'Product List';
    }
    Shop.ɵfac = function Shop_Factory(t) { return new (t || Shop)(); };
    Shop.ɵcmp = i0.ɵɵdefineComponent({ type: Shop, selectors: [["the-shop"]], decls: 8, vars: 1, consts: [[1, "row"], [1, "col-md-9"], [1, "col-md-3"], [1, "card", "bg-light", "p-2"]], template: function Shop_Template(rf, ctx) { if (rf & 1) {
            i0.ɵɵelementStart(0, "div", 0);
            i0.ɵɵelementStart(1, "div", 1);
            i0.ɵɵelementStart(2, "h3");
            i0.ɵɵtext(3);
            i0.ɵɵelementEnd();
            i0.ɵɵelement(4, "product-list");
            i0.ɵɵelementEnd();
            i0.ɵɵelementStart(5, "div", 2);
            i0.ɵɵelementStart(6, "div", 3);
            i0.ɵɵelement(7, "the-cart");
            i0.ɵɵelementEnd();
            i0.ɵɵelementEnd();
            i0.ɵɵelementEnd();
        } if (rf & 2) {
            i0.ɵɵadvance(3);
            i0.ɵɵtextInterpolate(ctx.title);
        } }, directives: [i1.ProductList, i2.Cart], encapsulation: 2 });
    return Shop;
}());
exports.Shop = Shop;
/*@__PURE__*/ (function () { i0.ɵsetClassMetadata(Shop, [{
        type: core_1.Component,
        args: [{
                selector: "the-shop",
                templateUrl: "shop.component.html"
            }]
    }], null, null); })();


/***/ }),

/***/ "fbMm":
/*!************************************************!*\
  !*** ./ClientApp/app/login/login.component.ts ***!
  \************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
exports.Login = void 0;
var core_1 = __webpack_require__(/*! @angular/core */ "fXoL");
var i0 = __webpack_require__(/*! @angular/core */ "fXoL");
var i1 = __webpack_require__(/*! ../shared/dataService */ "g4ZZ");
var i2 = __webpack_require__(/*! @angular/router */ "tyNb");
var i3 = __webpack_require__(/*! @angular/common */ "ofXK");
var i4 = __webpack_require__(/*! @angular/forms */ "3Pt+");
function Login_div_2_Template(rf, ctx) { if (rf & 1) {
    i0.ɵɵelementStart(0, "div", 15);
    i0.ɵɵtext(1);
    i0.ɵɵelementEnd();
} if (rf & 2) {
    var ctx_r0 = i0.ɵɵnextContext();
    i0.ɵɵadvance(1);
    i0.ɵɵtextInterpolate(ctx_r0.errorMessage);
} }
function Login_div_10_Template(rf, ctx) { if (rf & 1) {
    i0.ɵɵelementStart(0, "div", 16);
    i0.ɵɵtext(1, "Username is required! ");
    i0.ɵɵelementEnd();
} }
function Login_div_16_Template(rf, ctx) { if (rf & 1) {
    i0.ɵɵelementStart(0, "div", 16);
    i0.ɵɵtext(1, "Password is required! ");
    i0.ɵɵelementEnd();
} }
var Login = /** @class */ (function () {
    function Login(data, router) {
        this.data = data;
        this.router = router;
        this.errorMessage = "";
        this.creds = {
            username: "",
            password: ""
        };
    }
    Login.prototype.onLogin = function () {
        var _this = this;
        this.errorMessage = "";
        this.data.login(this.creds)
            .subscribe(function (success) {
            if (success) {
                if (_this.data.order.items.length == 0) {
                    _this.router.navigate([""]);
                }
                else {
                    _this.router.navigate(["checkout"]);
                }
            }
        }, function (err) { return _this.errorMessage = "Failed to login"; });
    };
    Login.ɵfac = function Login_Factory(t) { return new (t || Login)(i0.ɵɵdirectiveInject(i1.DataService), i0.ɵɵdirectiveInject(i2.Router)); };
    Login.ɵcmp = i0.ɵɵdefineComponent({ type: Login, selectors: [["login"]], decls: 21, vars: 6, consts: [[1, "row"], [1, "col-md-4", "offset-md-4"], ["class", "alert alert-warning", 4, "ngIf"], ["novalidate", "", 3, "submit"], ["theForm", "ngForm"], [1, "form-group"], ["for", "username"], ["type", "text", "name", "username", "required", "", 1, "form-control", 3, "ngModel", "ngModelChange"], ["username", "ngModel"], ["class", "text-danger", 4, "ngIf"], ["for", "password"], ["type", "password", "name", "password", "required", "", 1, "form-control", 3, "ngModel", "ngModelChange"], ["password", "ngModel"], ["type", "submit", "value", "Login", 1, "btn", "btn-success", 3, "disabled"], ["routerLink", "/", 1, "btn", "btn-default"], [1, "alert", "alert-warning"], [1, "text-danger"]], template: function Login_Template(rf, ctx) { if (rf & 1) {
            i0.ɵɵelementStart(0, "div", 0);
            i0.ɵɵelementStart(1, "div", 1);
            i0.ɵɵtemplate(2, Login_div_2_Template, 2, 1, "div", 2);
            i0.ɵɵelementStart(3, "form", 3, 4);
            i0.ɵɵlistener("submit", function Login_Template_form_submit_3_listener() { return ctx.onLogin(); });
            i0.ɵɵelementStart(5, "div", 5);
            i0.ɵɵelementStart(6, "label", 6);
            i0.ɵɵtext(7, "Username");
            i0.ɵɵelementEnd();
            i0.ɵɵelementStart(8, "input", 7, 8);
            i0.ɵɵlistener("ngModelChange", function Login_Template_input_ngModelChange_8_listener($event) { return ctx.creds.username = $event; });
            i0.ɵɵelementEnd();
            i0.ɵɵtemplate(10, Login_div_10_Template, 2, 0, "div", 9);
            i0.ɵɵelementEnd();
            i0.ɵɵelementStart(11, "div", 5);
            i0.ɵɵelementStart(12, "label", 10);
            i0.ɵɵtext(13, "Password");
            i0.ɵɵelementEnd();
            i0.ɵɵelementStart(14, "input", 11, 12);
            i0.ɵɵlistener("ngModelChange", function Login_Template_input_ngModelChange_14_listener($event) { return ctx.creds.password = $event; });
            i0.ɵɵelementEnd();
            i0.ɵɵtemplate(16, Login_div_16_Template, 2, 0, "div", 9);
            i0.ɵɵelementEnd();
            i0.ɵɵelementStart(17, "div", 5);
            i0.ɵɵelement(18, "input", 13);
            i0.ɵɵelementStart(19, "a", 14);
            i0.ɵɵtext(20, "Cancel");
            i0.ɵɵelementEnd();
            i0.ɵɵelementEnd();
            i0.ɵɵelementEnd();
            i0.ɵɵelementEnd();
            i0.ɵɵelementEnd();
        } if (rf & 2) {
            var _r1 = i0.ɵɵreference(4);
            var _r2 = i0.ɵɵreference(9);
            var _r4 = i0.ɵɵreference(15);
            i0.ɵɵadvance(2);
            i0.ɵɵproperty("ngIf", ctx.errorMessage);
            i0.ɵɵadvance(6);
            i0.ɵɵproperty("ngModel", ctx.creds.username);
            i0.ɵɵadvance(2);
            i0.ɵɵproperty("ngIf", _r2.touched && _r2.invalid && _r2.errors.required);
            i0.ɵɵadvance(4);
            i0.ɵɵproperty("ngModel", ctx.creds.password);
            i0.ɵɵadvance(2);
            i0.ɵɵproperty("ngIf", _r4.touched && _r4.invalid && _r4.errors.required);
            i0.ɵɵadvance(2);
            i0.ɵɵproperty("disabled", _r1.invalid);
        } }, directives: [i3.NgIf, i4.ɵangular_packages_forms_forms_y, i4.NgControlStatusGroup, i4.NgForm, i4.DefaultValueAccessor, i4.RequiredValidator, i4.NgControlStatus, i4.NgModel, i2.RouterLinkWithHref], encapsulation: 2 });
    return Login;
}());
exports.Login = Login;
/*@__PURE__*/ (function () { i0.ɵsetClassMetadata(Login, [{
        type: core_1.Component,
        args: [{
                selector: "login",
                templateUrl: "login.component.html"
            }]
    }], function () { return [{ type: i1.DataService }, { type: i2.Router }]; }, null); })();


/***/ }),

/***/ "g4ZZ":
/*!*********************************************!*\
  !*** ./ClientApp/app/shared/dataService.ts ***!
  \*********************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
exports.DataService = void 0;
var http_1 = __webpack_require__(/*! @angular/common/http */ "tk/3");
var core_1 = __webpack_require__(/*! @angular/core */ "fXoL");
var operators_1 = __webpack_require__(/*! rxjs/operators */ "kU1M");
var order_1 = __webpack_require__(/*! ./order */ "JqFU");
var i0 = __webpack_require__(/*! @angular/core */ "fXoL");
var i1 = __webpack_require__(/*! @angular/common/http */ "tk/3");
var DataService = /** @class */ (function () {
    function DataService(http) {
        this.http = http;
        this.token = "";
        this.tokenExpiration = new Date();
        this.order = new order_1.Order();
        this.products = [];
    }
    DataService.prototype.loadProducts = function () {
        var _this = this;
        return this.http.get("/api/products")
            .pipe(operators_1.map(function (data) {
            _this.products = data;
            return true;
        }));
    };
    Object.defineProperty(DataService.prototype, "loginRequired", {
        get: function () {
            return this.token.length == 0 || this.tokenExpiration > new Date();
        },
        enumerable: false,
        configurable: true
    });
    DataService.prototype.login = function (creds) {
        var _this = this;
        return this.http.post("/account/createtoken", creds)
            .pipe(operators_1.map(function (response) {
            var tokenInfo = response;
            _this.token = tokenInfo.token;
            _this.tokenExpiration = tokenInfo.expiration;
            return true;
        }));
    };
    DataService.prototype.checkout = function () {
        var _this = this;
        if (!this.order.orderNumber) {
            this.order.orderNumber = this.order.orderDate.getFullYear().toString() + this.order.orderDate.getTime().toString();
        }
        return this.http.post("/api/orders", this.order, {
            headers: new http_1.HttpHeaders({ "Authorization": "Bearer " + this.token })
        })
            .pipe(operators_1.map(function (response) {
            _this.order = new order_1.Order();
            return true;
        }));
    };
    DataService.prototype.addToOrder = function (product) {
        var item = this.order.items.find(function (i) { return i.productId == product.id; });
        if (item) {
            item.quantity++;
        }
        else {
            item = new order_1.OrderItem();
            item.productId = product.id;
            item.productArtist = product.artist;
            item.productCategory = product.category;
            item.productArtId = product.artId;
            item.productTitle = product.title;
            item.productSize = product.size;
            item.unitPrice = product.price;
            item.quantity = 1;
            this.order.items.push(item);
        }
    };
    DataService.ɵfac = function DataService_Factory(t) { return new (t || DataService)(i0.ɵɵinject(i1.HttpClient)); };
    DataService.ɵprov = i0.ɵɵdefineInjectable({ token: DataService, factory: DataService.ɵfac });
    return DataService;
}());
exports.DataService = DataService;
/*@__PURE__*/ (function () { i0.ɵsetClassMetadata(DataService, [{
        type: core_1.Injectable
    }], function () { return [{ type: i1.HttpClient }]; }, null); })();


/***/ }),

/***/ "lTML":
/*!**********************************************!*\
  !*** ./ClientApp/app/shop/cart.component.ts ***!
  \**********************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
exports.Cart = void 0;
var core_1 = __webpack_require__(/*! @angular/core */ "fXoL");
var i0 = __webpack_require__(/*! @angular/core */ "fXoL");
var i1 = __webpack_require__(/*! ../shared/dataService */ "g4ZZ");
var i2 = __webpack_require__(/*! @angular/router */ "tyNb");
var i3 = __webpack_require__(/*! @angular/common */ "ofXK");
function Cart_tr_19_Template(rf, ctx) { if (rf & 1) {
    i0.ɵɵelementStart(0, "tr");
    i0.ɵɵelementStart(1, "td");
    i0.ɵɵtext(2);
    i0.ɵɵelementEnd();
    i0.ɵɵelementStart(3, "td");
    i0.ɵɵtext(4);
    i0.ɵɵelementEnd();
    i0.ɵɵelementStart(5, "td");
    i0.ɵɵtext(6);
    i0.ɵɵpipe(7, "currency");
    i0.ɵɵelementEnd();
    i0.ɵɵelementStart(8, "td");
    i0.ɵɵtext(9);
    i0.ɵɵpipe(10, "currency");
    i0.ɵɵelementEnd();
    i0.ɵɵelementEnd();
} if (rf & 2) {
    var o_r2 = ctx.$implicit;
    i0.ɵɵadvance(2);
    i0.ɵɵtextInterpolate2("", o_r2.productCategory, " - ", o_r2.productTitle, "");
    i0.ɵɵadvance(2);
    i0.ɵɵtextInterpolate(o_r2.quantity);
    i0.ɵɵadvance(2);
    i0.ɵɵtextInterpolate(i0.ɵɵpipeBind3(7, 5, o_r2.unitPrice, "USD", "symbol"));
    i0.ɵɵadvance(3);
    i0.ɵɵtextInterpolate(i0.ɵɵpipeBind3(10, 9, o_r2.unitPrice * o_r2.quantity, "USD", "symbol"));
} }
function Cart_button_20_Template(rf, ctx) { if (rf & 1) {
    var _r4 = i0.ɵɵgetCurrentView();
    i0.ɵɵelementStart(0, "button", 3);
    i0.ɵɵlistener("click", function Cart_button_20_Template_button_click_0_listener() { i0.ɵɵrestoreView(_r4); var ctx_r3 = i0.ɵɵnextContext(); return ctx_r3.onCheckout(); });
    i0.ɵɵtext(1, "Checkout");
    i0.ɵɵelementEnd();
} }
var Cart = /** @class */ (function () {
    function Cart(data, router) {
        this.data = data;
        this.router = router;
    }
    Cart.prototype.onCheckout = function () {
        if (this.data.loginRequired) {
            // Force Login
            this.router.navigate(["login"]);
        }
        else {
            // Go to checkout
            this.router.navigate(["checkout"]);
        }
    };
    Cart.ɵfac = function Cart_Factory(t) { return new (t || Cart)(i0.ɵɵdirectiveInject(i1.DataService), i0.ɵɵdirectiveInject(i2.Router)); };
    Cart.ɵcmp = i0.ɵɵdefineComponent({ type: Cart, selectors: [["the-cart"]], decls: 21, vars: 8, consts: [[1, "table", "table-sm", "table-hover"], [4, "ngFor", "ngForOf"], ["class", "btn btn-success", 3, "click", 4, "ngIf"], [1, "btn", "btn-success", 3, "click"]], template: function Cart_Template(rf, ctx) { if (rf & 1) {
            i0.ɵɵelementStart(0, "h3");
            i0.ɵɵtext(1, "Shopping Cart");
            i0.ɵɵelementEnd();
            i0.ɵɵelementStart(2, "div");
            i0.ɵɵtext(3);
            i0.ɵɵelementEnd();
            i0.ɵɵelementStart(4, "div");
            i0.ɵɵtext(5);
            i0.ɵɵpipe(6, "currency");
            i0.ɵɵelementEnd();
            i0.ɵɵelementStart(7, "table", 0);
            i0.ɵɵelementStart(8, "thead");
            i0.ɵɵelementStart(9, "tr");
            i0.ɵɵelementStart(10, "td");
            i0.ɵɵtext(11, "Product");
            i0.ɵɵelementEnd();
            i0.ɵɵelementStart(12, "td");
            i0.ɵɵtext(13, "#");
            i0.ɵɵelementEnd();
            i0.ɵɵelementStart(14, "td");
            i0.ɵɵtext(15, "$");
            i0.ɵɵelementEnd();
            i0.ɵɵelementStart(16, "td");
            i0.ɵɵtext(17, "Total");
            i0.ɵɵelementEnd();
            i0.ɵɵelementEnd();
            i0.ɵɵelementEnd();
            i0.ɵɵelementStart(18, "tbody");
            i0.ɵɵtemplate(19, Cart_tr_19_Template, 11, 13, "tr", 1);
            i0.ɵɵelementEnd();
            i0.ɵɵelementEnd();
            i0.ɵɵtemplate(20, Cart_button_20_Template, 2, 0, "button", 2);
        } if (rf & 2) {
            i0.ɵɵadvance(3);
            i0.ɵɵtextInterpolate1("#/Items: ", ctx.data.order.items.length, "");
            i0.ɵɵadvance(2);
            i0.ɵɵtextInterpolate1("Subtotal: ", i0.ɵɵpipeBind3(6, 4, ctx.data.order.subtotal, "USD", "symbol"), "");
            i0.ɵɵadvance(14);
            i0.ɵɵproperty("ngForOf", ctx.data.order.items);
            i0.ɵɵadvance(1);
            i0.ɵɵproperty("ngIf", ctx.data.order.items.length > 0);
        } }, directives: [i3.NgForOf, i3.NgIf], pipes: [i3.CurrencyPipe], encapsulation: 2 });
    return Cart;
}());
exports.Cart = Cart;
/*@__PURE__*/ (function () { i0.ɵsetClassMetadata(Cart, [{
        type: core_1.Component,
        args: [{
                selector: "the-cart",
                templateUrl: "cart.component.html",
                styleUrls: []
            }]
    }], function () { return [{ type: i1.DataService }, { type: i2.Router }]; }, null); })();


/***/ }),

/***/ "zn8P":
/*!******************************************************!*\
  !*** ./$$_lazy_route_resource lazy namespace object ***!
  \******************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

function webpackEmptyAsyncContext(req) {
	// Here Promise.resolve().then() is used instead of new Promise() to prevent
	// uncaught exception popping up in devtools
	return Promise.resolve().then(function() {
		var e = new Error("Cannot find module '" + req + "'");
		e.code = 'MODULE_NOT_FOUND';
		throw e;
	});
}
webpackEmptyAsyncContext.keys = function() { return []; };
webpackEmptyAsyncContext.resolve = webpackEmptyAsyncContext;
module.exports = webpackEmptyAsyncContext;
webpackEmptyAsyncContext.id = "zn8P";

/***/ })

},[[0,"runtime","vendor"]]]);
//# sourceMappingURL=main.js.map