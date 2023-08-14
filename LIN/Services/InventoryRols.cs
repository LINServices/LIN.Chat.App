namespace LIN.Services;


internal static class InventoryRolesExtensions
{

    /// <summary>
    /// Comprueba si tiene acceso para leer un inventario
    /// </summary>
    public static bool HasReadPermissions(this InventoryRoles rol)
    {
        InventoryRoles[] rols = { InventoryRoles.Administrator, InventoryRoles.Member, InventoryRoles.Guest };
        return rols.Contains(rol);
    }



    /// <summary>
    /// Comprueba si tiene acceso para crear / actualizar los productos de un inventario
    /// </summary>
    public static bool HasProductUpdatePermissions(this InventoryRoles rol)
    {
        InventoryRoles[] rols = { InventoryRoles.Administrator, InventoryRoles.Member };
        return rols.Contains(rol);
    }



    /// <summary>
    /// Comprueba si tiene acceso para crear / actualizar los movimientos de un inventario
    /// </summary>
    public static bool HasMovementUpdatePermissions(this InventoryRoles rol)
    {
        InventoryRoles[] rols = { InventoryRoles.Administrator, InventoryRoles.Member };
        return rols.Contains(rol);
    }



    /// <summary>
    /// Comprueba si tiene acceso para leer los movimientos de un inventario
    /// </summary>
    public static bool HasMovementReadPermissions(this InventoryRoles rol)
    {
        InventoryRoles[] rols = { InventoryRoles.Administrator, InventoryRoles.Member, InventoryRoles.Guest };
        return rols.Contains(rol);
    }


}
