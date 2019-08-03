declare module Server.Dtos {
	interface Commands {
		commandsID: number;
		command: string;
		projectsID: number;
		concurrency: any[];
		projects: {
			projectsID: number;
			project: string;
			description: string;
			concurrency: any[];
			variables: any[];
			commands: Server.Dtos.Commands[];
		};
	}
}
