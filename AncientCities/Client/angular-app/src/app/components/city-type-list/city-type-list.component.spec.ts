import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CityTypeListComponent } from './city-type-list.component';

describe('CityTypeListComponent', () => {
  let component: CityTypeListComponent;
  let fixture: ComponentFixture<CityTypeListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CityTypeListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CityTypeListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
