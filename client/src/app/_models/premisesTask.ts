export interface PremisesTask {
    id: number;
    title: string;
    description: string;
    completionDate: Date;
    noteId?: any;
    isDeleted: boolean;
    premisesId: number;
}
