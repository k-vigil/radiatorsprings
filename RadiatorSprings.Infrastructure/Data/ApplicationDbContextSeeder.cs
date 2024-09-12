using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace RadiatorSprings.Infrastructure.Data;

public static class ApplicationDbContextSeeder
{
    public static IApplicationBuilder Seed(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var _context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        List<Permission> permissions = new()
        {
            // permisos para modulos de permisos y usuarios
            new("view_permissions", "Permiso para acceder a lista de permisos"),
            new("view_users", "Permiso para acceder a lista de usuarios"),
            new("view_single_user", "Permiso para acceder a un usuario"),
            new("add_user", "Permiso para acceder a agregar un usuario"),
            // permisos para modulo de categorias
            new("view_categories", "Permiso para acceder a lista de categorias"),
            new("view_single_category", "Permiso para acceder a una categoria"),
            new("add_category", "Permisso para acceder a agregar una categoria"),
            new("update_category", "Permiso para acceder a actualizar una categoria"),
            // permisos para modulo de vehiculos
            new("view_vehicles", "Permiso para acceder a lista de vehiculos"),
            new("view_single_vehicle", "Permiso para acceder a un vehiculo"),
            new("add_vehicle", "Permisso para acceder a agregar un vehiculo"),
            new("update_vehicle", "Permiso para acceder a actualizar un vehiculo"),
            // permisos para modulo de clientes
            new("view_customers", "Permiso para acceder a lista de clientes"),
            new("view_single_customer", "Permiso para acceder a un cliente"),
            new("add_customer", "Permisso para acceder a agregar un cliente"),
            new("update_customer", "Permiso para acceder a actualizar un cliente"),
            // permisos para modulo de reservas
            new("view_bookings", "Permiso para acceder a lista de reservas"),
            new("view_single_booking", "Permiso para acceder a una reserva"),
            new("add_booking", "Permisso para acceder a agregar una reserva"),
        };

        List<User> users = new()
        {
            new("John Doe", "johnd"),
            new("Mark Carter", "markc")
        };

        List<UserPermission> userPermissions = new()
        {
            // usuario 1 tiene todos los permisos
            new(1, 1),
            new(1, 2),
            new(1, 3),
            new(1, 4),
            new(1, 5),
            new(1, 6),
            new(1, 7),
            new(1, 8),
            new(1, 9),
            new(1, 10),
            new(1, 11),
            new(1, 12),
            new(1, 13),
            new(1, 14),
            new(1, 15),
            new(1, 16),
            new(1, 17),
            new(1, 18),
            new(1, 19),
            // usuario 2 solo puede acceder a reservas
            new(2, 17),
            new(2, 18),
        };

        foreach (var permission in permissions)
            _context.Permissions.Add(permission);

        _context.SaveChanges();

        foreach (var user in users)
            _context.Users.Add(user);

        _context.SaveChanges();

        foreach (var userPermission in userPermissions)
            _context.UserPermissions.Add(userPermission);

        _context.SaveChanges();

        return app;
    }
}
