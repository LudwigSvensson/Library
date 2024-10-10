export interface Book {
    bookId: string;
    title: string;  
    author: string;
    bookGenre: BookGenre;
    realeseYear: Date;
}

export enum BookGenre {
    Deckare = 'Deckare',
    Biografi = 'Biografi',
    Romantik= 'Romantik',
    Fantasy= 'Fantasy',
    Scifi= 'Scifi',
    Självbiografi= 'Självbiografi',
}
