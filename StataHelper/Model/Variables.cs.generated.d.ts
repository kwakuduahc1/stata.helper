declare module Server.Dtos {
	interface Variables {
		variablesID: number;
		variable: string;
		projectsID: number;
		description: string;
		concurrency: any[];
		projects: {
			projectsID: number;
			project: string;
			description: string;
			concurrency: any[];
			variables: Server.Dtos.Variables[];
		};
		varlabs: any[];
	}
}
