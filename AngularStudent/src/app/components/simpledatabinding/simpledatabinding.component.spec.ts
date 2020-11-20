import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SimpledatabindingComponent } from './simpledatabinding.component';

describe('SimpledatabindingComponent', () => {
  let component: SimpledatabindingComponent;
  let fixture: ComponentFixture<SimpledatabindingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SimpledatabindingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SimpledatabindingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
