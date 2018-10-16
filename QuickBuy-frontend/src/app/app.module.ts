import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthGuardService } from './shared/services/auth-guard.service';
import { AuthService } from './shared/services/auth.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { FooterComponent } from './components/footer/footer.component';
import { ProductComponent } from './components/product/product.component';
import { SearchComponent } from './components/search/search.component';
import { ProductListComponent } from './components/product-list/product-list.component';
import { AppRoutingModule } from './app-routing.module';
import { HomeComponent } from './pages/home/home.component';
import { SearchService } from './shared/services/search.service';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { ApiInterceptor } from './shared/interceptors/api.interceptor';
import { ProductDetailComponent } from './pages/product-detail/product-detail.component';
import { FindComponent } from './pages/find/find.component';
import { ProductListInitialComponent } from './components/product-list-initial/product-list-initial.component';
import { TokenInterceptor } from './shared/interceptors/token.interceptor';
import { SignInComponent } from './pages/auth/sign-in/sign-in.component';
import { SignUpComponent } from './pages/auth/sign-up/sign-up.component';
import { JwtModule } from '@auth0/angular-jwt';
import { UserDetailComponent } from './pages/user-detail/user-detail.component';
import { HeaderComponent } from './components/header/header.component';
import { ProductService } from './shared/services/product.service';
import { AddProductComponent } from './pages/add-product/add-product.component';
import { CategoryPipe } from './shared/pipes/category.pipe';
import { MyBoughtProductsComponent } from './pages/my-bought-products/my-bought-products.component';
import { MyBoughtProductListComponent } from './components/my-bought-product-list/my-bought-product-list.component';
import { MyBoughtProductComponent } from './components/my-bought-product/my-bought-product.component';

export function tokenGetter() {
  return localStorage.getItem('token');
}

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    ProductComponent,
    SearchComponent,
    ProductListComponent,
    HomeComponent,
    ProductDetailComponent,
    FindComponent,
    ProductListInitialComponent,
    SignInComponent,
    SignUpComponent,
    UserDetailComponent,
    AddProductComponent,
    CategoryPipe,
    MyBoughtProductsComponent,
    MyBoughtProductListComponent,
    MyBoughtProductComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
      }
    }),
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    JwtHelperService,
    SearchService,
    ProductService,
    AuthService,
    AuthGuardService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ApiInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
