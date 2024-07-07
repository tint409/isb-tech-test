import { Component, inject } from '@angular/core';
import { NgFor, NgIf } from '@angular/common';
import { Property } from '../interfaces/property';
import { PropertyService } from '../property.service';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [NgFor, NgIf],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent {

  propertyService: PropertyService = inject(PropertyService);

  SelectedProperty: Property | null = {
    id: '',
    name: 'Not Selected'
  };
  AllProperties: Property[] = [];

  constructor() {
    this.propertyService.getAllProperties().then(data => this.AllProperties = data);
  }

  onClick(item: Property): void {
    this.propertyService.getProperty(item.id).then(data => this.SelectedProperty = data);
  }
}
