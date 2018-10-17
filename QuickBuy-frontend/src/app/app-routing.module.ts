import { EditProductComponent } from './pages/edit-product/edit-product.component';
import { MyBoughtProductsComponent } from './pages/my-bought-products/my-bought-products.component';
import { AddProductComponent } from './pages/add-product/add-product.component';
import { UserDetailComponent } from './pages/user-detail/user-detail.component';
import { SignInComponent } from './pages/auth/sign-in/sign-in.component';
import { SignUpComponent } from './pages/auth/sign-up/sign-up.component';
import { FindComponent } from './pages/find/find.component';
import { HomeComponent } from './pages/home/home.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProductDetailComponent } from './pages/product-detail/product-detail.component';
import { AuthGuardService } from './shared/services/auth-guard.service';
import { MyProductsComponent } from './pages/my-products/my-products.component';
const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'product/:id',
    component: ProductDetailComponent
  },
  {
    path: 'find/:category/:keyword',
    component: FindComponent
  },
  {
    path: 'find/:keyword',
    component: FindComponent
  },
  {
    path: 'find',
    component: FindComponent
  },
  {
    path: 'signup',
    component: SignUpComponent
  },
  {
    path: 'signin',
    component: SignInComponent
  },
  {
    path: 'user',
    component: UserDetailComponent,
    canActivate: [AuthGuardService]
  },
  {
    path: 'addProduct',
    component: AddProductComponent,
    canActivate: [AuthGuardService]
  },
  {
    path: 'myBoughtProducts',
    component: MyBoughtProductsComponent,
    canActivate: [AuthGuardService]
  },
  {
    path: 'myProducts',
    component: MyProductsComponent,
    canActivate: [AuthGuardService]
  },
  {
    path: 'editProduct/:id',
    component: EditProductComponent,
    canActivate: [AuthGuardService]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
