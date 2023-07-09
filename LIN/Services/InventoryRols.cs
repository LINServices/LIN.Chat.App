namespace LIN.Services;


internal static class InventoryRolsExtensions
{

    /// <summary>
    /// Comprueba si tiene acceso para leer un inventario
    /// </summary>
    public static bool HasReadPermissions(this InventoryRols rol)
    {
        InventoryRols[] rols = { InventoryRols.Administrator, InventoryRols.Member, InventoryRols.Guest };
        return rols.Contains(rol);
    }



    /// <summary>
    /// Comprueba si tiene acceso para crear / actualizar los productos de un inventario
    /// </summary>
    public static bool HasProductUpdatePermissions(this InventoryRols rol)
    {
        InventoryRols[] rols = { InventoryRols.Administrator, InventoryRols.Member };
        return rols.Contains(rol);
    }



    /// <summary>
    /// Comprueba si tiene acceso para crear / actualizar los movimientos de un inventario
    /// </summary>
    public static bool HasMovementUpdatePermissions(this InventoryRols rol)
    {
        InventoryRols[] rols = { InventoryRols.Administrator, InventoryRols.Member };
        return rols.Contains(rol);
    }



    /// <summary>
    /// Comprueba si tiene acceso para leer los movimientos de un inventario
    /// </summary>
    public static bool HasMovementReadPermissions(this InventoryRols rol)
    {
        InventoryRols[] rols = { InventoryRols.Administrator, InventoryRols.Member, InventoryRols.Guest };
        return rols.Contains(rol);
    }


}
