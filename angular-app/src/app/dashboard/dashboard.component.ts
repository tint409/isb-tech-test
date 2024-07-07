import { Component, inject } from '@angular/core';
import { NgFor, NgIf, DatePipe, DecimalPipe } from '@angular/common';
import { Property } from '../interfaces/property';
import { PropertyService } from '../property.service';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [NgFor, NgIf, DatePipe, DecimalPipe],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css',
})
export class DashboardComponent {

  propertyService: PropertyService = inject(PropertyService);

  SelectedProperty: Property | null = {
    id: '',
    name: 'Please select a above property',
    ownershipChanges: []
  };
  AllProperties: Property[] = [];

  constructor() {
    this.propertyService.getAllProperties().then(data => this.AllProperties = data);
  }

  onClick(item: Property): void {
    this.propertyService.getProperty(item.id).then(data => this.SelectedProperty = data);
  }
}
