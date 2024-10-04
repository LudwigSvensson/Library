export interface Book {
    bookId: string; // Book ID
    title: string; // Book Title
    author: string; // Book Author
    bookGenre: string; // Book Genre        
    realeseYear: string; // Book Release
    } // Book Genre        
    export enum BookGenre {
        Deckare = 'Deckare',
        Biografi = 'Biografi',
        Romantik = 'Romantik',
        Fantasy = 'Fantasy',
        ScienceFiction = 'ScienceFiction',
        Självbiografi = 'Självbiografi',
    }