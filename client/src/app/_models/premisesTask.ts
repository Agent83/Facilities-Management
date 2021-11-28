export interface PremisesTask {
    id: string;
    dateCreated: Date;
    completionDate: Date;
    title: string;
    description: string;
    noteId?: any;
    isDeleted: boolean;
    premisesId: string;
    premises?: any;
}
