# Usage Examples

## Fetching a Product

```csharp
var product = await _productService.GetProductByIdAsync(Guid.NewGuid());
Console.WriteLine($"Product Name: {product.Name}");
