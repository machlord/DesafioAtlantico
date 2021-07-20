import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CaixasComponent } from './caixas.component';

describe('CaixasComponent', () => {
  let component: CaixasComponent;
  let fixture: ComponentFixture<CaixasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CaixasComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CaixasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
