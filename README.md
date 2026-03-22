# APBD-Cw1-s32188

## Opis projektu
Projekt aplikacji konsolowej do zarządzania wypożyczaniem sprzętu uczelnianego.
System pozwala na dodawanie sprzętu i użytkowników, wypożyczanie i zwroty sprzętu, naliczanie kar za opóźnienia oraz generowanie raportów.


## Podział klas i warstw

- **Models/** – klasy domenowe (`User`, `Equipment`, `Rental`) i ich podtypy. 
- **Services/** – logika biznesowa:
  - `UserService` – zarządza użytkownikami.
  - `EquipmentService` – zarządza sprzętem i jego dostępnością.
  - `RentalService` – obsługuje wypożyczenia, zwroty, kary i raporty.
- **Exceptions/** – własne wyjątki do jawnego obsługiwania błędów w domenie.
- **Enums/** – typy wyliczeniowe używane w logice biznesowej.


## Kohezja, coupling i odpowiedzialność

- **Kohezja:** każda klasa i serwis zajmuje się tylko tym, do czego została stworzona. Na przykład `RentalService` odpowiada za wypożyczenia, zwroty, kary i raporty, ale nie manipuluje bezpośrednio listą użytkowników ani sprzętu.
- **Coupling:** serwisy komunikują się ze sobą przez interfejsy (`IUserService`, `IEquipmentService`). Dzięki temu można łatwo podmienić implementację lub testować poszczególne elementy bez wpływu na resztę systemu. 
- **Odpowiedzialność:** modele przechowują dane, a serwisy realizują reguły biznesowe i kontrolują przepływ operacji

## Uzasadnienie decyzji projektowych

- Podział na modele i serwisy pozwala oddzielić logikę biznesową od danych i interfejsu konsolowego.  
- Dziedziczenie w modelach zastosowano tylko tam, gdzie faktycznie wydziela cechy wspólne od specyficznych.  
- Dzięki temu projekt jest czytelny, łatwy do testowania i rozszerzania, a wprowadzenie zmian w zasadach biznesowych wymaga modyfikacji tylko w jednym serwisie.
