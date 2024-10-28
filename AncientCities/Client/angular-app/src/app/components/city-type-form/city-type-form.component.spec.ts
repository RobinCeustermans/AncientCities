import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CityTypeFormComponent } from './city-type-form.component';

describe('CityTypeFormComponent', () => {
  let component: CityTypeFormComponent;
  let fixture: ComponentFixture<CityTypeFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CityTypeFormComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CityTypeFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
