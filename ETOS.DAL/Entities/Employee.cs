using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

using ETOS.DAL.Interfaces;

namespace ETOS.DAL.Entities
{
	/// <summary>
	/// ��������� �������� "���������".
	/// ������ �������� ������������ ����� ���������� ��������.
	/// </summary>
	public class Employee : IEntity
	{
		#region Fields

		/// <summary>
		/// ��������� ����� ����������.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// ������� ����������.
		/// </summary>
		public string Lastname { get; set; }

		/// <summary>
		/// ��� ����������.
		/// </summary>
		public string Firstname { get; set; }

		/// <summary>
		/// �������� ����������.
		/// </summary>
		public string Patronymic { get; set; }

		/// <summary>
		/// ����� �������� ����������.
		/// </summary>
		public string Phone { get; set; }

		/// <summary>
		/// ����� ����������� ����� ����������.
		/// </summary>
		public string Email { get; set; }
		
		/// <summary>
		/// ��� �������, � ������� ��������� ���������.
		/// </summary>
		public int LocationId { get; set; }

		/// <summary>
		/// ��� ������������, �� ������� ��������� ���������.
		/// </summary>
		public int OrgstructureId { get; set; }

		/// <summary>
		/// ��� ���������, ���������� �����������.
		/// </summary>
		public int PositionId { get; set; }

		/// <summary>
		/// ��� ������� ������ ���������� � �������.
		/// </summary>
		public string UserId { get; set; }

		#endregion

		#region Navigation properties

		/// <summary>
		/// �������, � ������� ��������� ���������.
		/// </summary>
		public virtual Location Location { get; set; }

		/// <summary>
		/// ������������, � ������� ���������� ���������.
		/// </summary>
		public virtual Orgstructure Orgstructure { get; set; }

		/// <summary>
		/// ���������, ���������� �����������.
		/// </summary>
		public virtual Position Position { get; set; }

		/// <summary>
		/// ������� ������ ���������� � �������.
		/// </summary>
		public virtual ApplicationUser User { get; set; }

		/// <summary>
		/// ������ ������, ������������ �����������.
		/// </summary>
		public virtual ICollection<Request> Requests { get; set; }

		#endregion
	}

	/// <summary>
	/// ��������� ������������ ������ �������� "���������".
	/// </summary>
	internal class EmployeeEntityTypeConfiguration : EntityTypeConfiguration<Employee>
	{
		public EmployeeEntityTypeConfiguration()
		{
			ToTable("Employees");

			HasKey(e => e.Id);

			Property(e => e.Lastname).HasMaxLength(50);
			Property(e => e.Firstname).HasMaxLength(50);
			Property(e => e.Patronymic).HasMaxLength(50);
			Property(e => e.Phone).HasMaxLength(16);
			Property(e => e.Email).HasMaxLength(50);
			Property(e => e.UserId).HasMaxLength(128);

			// ����� "����-��-������" � ��������� "�������".
			HasRequired(e => e.Location)
				.WithMany()
				.HasForeignKey(e => e.LocationId);

			// ����� "����-��-������" � ��������� "������������".
			HasRequired(e => e.Orgstructure)
				.WithMany()
				.HasForeignKey(e => e.OrgstructureId);

			// ����� "����-��-������" � ��������� "���������".
			HasRequired(e => e.Position)
				.WithMany()
				.HasForeignKey(e => e.PositionId);

			// ����� "����-��-������" � ��������� "������� ������".
			HasRequired(e => e.User)
				.WithMany()
				.HasForeignKey(e => e.UserId);

			// ����� "����-��-������" � ��������� "������".
			HasMany(e => e.Requests)
				.WithOptional(r => r.Employee)
				.HasForeignKey(r => r.EmployeeId);
		}
	}
}
