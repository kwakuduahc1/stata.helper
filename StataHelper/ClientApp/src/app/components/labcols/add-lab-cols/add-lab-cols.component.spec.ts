import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddLabColsComponent } from './add-lab-cols.component';

describe('AddLabColsComponent', () => {
  let component: AddLabColsComponent;
  let fixture: ComponentFixture<AddLabColsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddLabColsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddLabColsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
