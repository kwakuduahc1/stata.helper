declare module Server.Dtos {
	interface Projects {
		projectsID: number;
		project: string;
		description: string;
		concurrency: any[];
		variables: any[];
		commands: any[];
	}
}
