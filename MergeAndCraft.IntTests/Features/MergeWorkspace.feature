Feature: MergeWorkspace

Test functionality of the MergeWorkspace, similating several scanerios.

@workspace
Scenario: Generate and merge some components
	Given MergeWorkspace is initialised with a width of <Width> and a height of <Height>
	And ComponentDirectory loaded with <ComponentConfigPaths>
	And MetalJunk WorkspaceGenerator configuration loaded from <MetalJunkGeneratorPath>

	Examples:

	| Width | Height | ComponentConfigPaths          | MetalJunkGeneratorPath           |
	| 10    | 10     | TestData/MetalComponents.json | TestData/MetalJunkGenerator.json |