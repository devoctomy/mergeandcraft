using MergeAndCraft.Game.Desktop.Services;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddSingleton<IGridLayoutService, GridLayoutService>();
using var game = new MergeAndCraft.Game.Desktop.Game(services.BuildServiceProvider());
game.Run();
