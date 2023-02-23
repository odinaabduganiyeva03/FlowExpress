using FlowExpress.Data.Repositories;
using FlowExpress.Domain.Entities;

var repo = new GenericRepository<Food>();

var food = new Food()
{
    Name = "olma",
    Count = 5,
    Description = "qizil",
    Price = 3000
};
await repo.CreateAsync(food);
