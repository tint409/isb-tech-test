import { Injectable } from '@angular/core';
import { Property } from './interfaces/property';

@Injectable({
  providedIn: 'root'
})
export class PropertyService {

  apiUrl = 'https://localhost:7016/property';
  
  constructor() { }

  async getAllProperties(): Promise<Property[]> {

    //const data = await this.http.get(this.apiUrl);

    const data = await fetch(this.apiUrl);
    return (await data.json()) ?? [];

    // return [
    //   {
    //     id: '1',
    //     name: 'Property 1'
    //   },
    //   {
    //     id: '2',
    //     name: 'Property 2'
    //   }];
  }
  async getProperty(id: string): Promise<Property | null> {
    const data = await fetch(`${this.apiUrl}/${id}`);
    return (await data.json()) ?? {};
  }
}
