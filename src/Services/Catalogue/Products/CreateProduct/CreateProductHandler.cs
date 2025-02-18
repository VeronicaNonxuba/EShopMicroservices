using System.Reflection.Metadata.Ecma335;
using BuildingBlocks.CQRS;
using Catalogue.API.Models;

namespace Catalogue.API.Products.CreateProduct;

public record CreateProductCommand(string Name, List<string> Category,
                string Description, string ImageFile, decimal Price)
                : ICommand<CreateProductResult>;
public record CreateProductResult(Guid Id);
internal class CreateProductCommandHandler :
        ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        //create product entity from incoming command object
        var product = new Product
        {
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price
        };

        //save to db


        //return CreateProductResult result
        return new CreateProductResult(Guid.NewGuid());
    }
}
