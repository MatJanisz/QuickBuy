import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductListInitialComponent } from './product-list-initial.component';

describe('ProductListInitialComponent', () => {
  let component: ProductListInitialComponent;
  let fixture: ComponentFixture<ProductListInitialComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProductListInitialComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductListInitialComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
