import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SpecialplantypesComponent } from './specialplantypes.component';

describe('SpecialplantypesComponent', () => {
  let component: SpecialplantypesComponent;
  let fixture: ComponentFixture<SpecialplantypesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SpecialplantypesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SpecialplantypesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
