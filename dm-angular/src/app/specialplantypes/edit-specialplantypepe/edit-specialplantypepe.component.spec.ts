import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditSpecialplantypepeComponent } from './edit-specialplantypepe.component';

describe('EditSpecialplantypepeComponent', () => {
  let component: EditSpecialplantypepeComponent;
  let fixture: ComponentFixture<EditSpecialplantypepeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditSpecialplantypepeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditSpecialplantypepeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
