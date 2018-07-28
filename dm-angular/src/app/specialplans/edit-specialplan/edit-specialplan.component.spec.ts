import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditSpecialplanComponent } from './edit-specialplan.component';

describe('EditSpecialplanComponent', () => {
  let component: EditSpecialplanComponent;
  let fixture: ComponentFixture<EditSpecialplanComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditSpecialplanComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditSpecialplanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
