import { Component, OnInit } from '@angular/core';
import { TerritoryService } from '../territory.service';  // Szolgáltatás importálása
import { HttpErrorResponse } from '@angular/common/http';  // Hiba kezeléshez

@Component({
  selector: 'app-territory-list',
  templateUrl: './territory-list.component.html',
  styleUrls: ['./territory-list.component.css']
})
export class TerritoryListComponent implements OnInit {
  territories: any[] = [];
  selectedTerritory: any = null;
  isAddingNew: boolean = false;  // Ha új territory hozzáadása folyamatban van
  newTerritory: any = { territoryid: '', territorydescription: '', regionid: '' }; // Az új territory adatainak tárolása

  constructor(private territoryService: TerritoryService) { }

  ngOnInit(): void {
    this.loadTerritories();
  }

  loadTerritories(): void {
    this.territoryService.getTerritories().subscribe(
      (data: any[]) => {
        this.territories = data;
        this.sortTerritories();
      },
      (error: HttpErrorResponse) => {
        console.error('Hiba történt az adatok betöltésekor:', error);
      }
    );
  }

  selectTerritory(territory: any): void {
    if (this.selectedTerritory === territory) {
      this.selectedTerritory = null;  // Ha ugyanazt választják, elrejtjük a szerkesztőt
    } else {
      this.selectedTerritory = territory;  // Kiválasztás
    }
  }

  updateTerritory(): void {
    if (!this.selectedTerritory) return;

    this.territoryService.updateTerritory(this.selectedTerritory).subscribe(
      (response) => {
        console.log('Frissítve:', response);
        this.loadTerritories();  // Frissítjük a táblázatot
        this.selectedTerritory = null;  // Elrejtjük a módosító űrlapot
      },
      (error) => {
        console.error('Hiba történt a frissítés során:', error);
      }
    );
  }

  cancelEdit(): void {
    this.selectedTerritory = null;  // A módosítások törlése
  }

  cancelAdd(): void {
    this.isAddingNew = false;  // Elrejti az új territory űrlapot
    this.newTerritory = { territoryid: '', territorydescription: '', regionid: '' }; // Törli az új territory adatait
  }

  addNewTerritory(): void {
    this.isAddingNew = true;  // Megjeleníti az új territory űrlapot
  }

  saveNewTerritory(): void {
    if (!this.newTerritory.territoryid || !this.newTerritory.territorydescription || !this.newTerritory.regionid) {
      console.error('Minden mezőt ki kell tölteni!');
      return;
    }

    this.territoryService.createTerritory(this.newTerritory).subscribe(
      (response) => {
        
        this.loadTerritories(); // Frissíti a területek listáját
        this.cancelAdd(); // Elrejti az új territory űrlapot
      }
    );

  }

  sortTerritories(): void {
    this.territories.sort((a, b) => a.territoryid - b.territoryid);
  }

  deleteTerritory(): void {
    if (!this.selectedTerritory) return;

    this.territoryService.deleteTerritory(this.selectedTerritory.territoryid).subscribe(
      (response) => {
        
        this.loadTerritories(); // Frissítjük a területek listáját
        this.selectedTerritory = null; // Elrejtjük a módosító űrlapot
      
      }
    );
  }

  createTerritory(): void {
    if (!this.newTerritory.territoryid || !this.newTerritory.territorydescription || !this.newTerritory.regionid) {
      console.error('Az összes mező kitöltése kötelező!');
      return;
    }
  }

}
