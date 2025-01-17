import { Component, OnInit } from '@angular/core';
import { PetService, Pet } from '../../services/pet.service';

@Component({
  selector: 'app-pet-list',
  standalone: false,
  
  templateUrl: './pet-list.component.html',
  styleUrls: ['./pet-list.component.css']
})
export class PetListComponent {
  pets: Pet[] = [];
  statuses = ['available', 'pending', 'sold'];
  selectedStatuses: string[] = ['available'];

  constructor(private petService: PetService) { }

  ngOnInit(): void {
    this.loadPets();
  }

  loadPets(): void {
    this.petService.findByStatus(this.selectedStatuses).subscribe(
      (data) => {
        this.pets = data;
      },
      (error) => {
        console.error('Error fetching pets:', error);
      }
    );
  }
}
