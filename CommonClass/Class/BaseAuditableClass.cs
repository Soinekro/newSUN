namespace CommonClass.Class
{
    public abstract class BaseAuditableClass
    {
        public bool SecStatus { get; set; } = true; // True = Activo, False = Eliminado Lógico
        public int SecUserId { get; set; } // ID del usuario que creó el registro
        public DateTime SecCreate { get; set; } = DateTime.UtcNow; // Fecha de creación
        public int? SecUserUpdate { get; set; } // ID del usuario que modificó (nullable)
        public DateTime? SecUpdate { get; set; } // Fecha de modificación (nullable)

    }
}
