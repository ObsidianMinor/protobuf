// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: unittest_import_proto3.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Google.Protobuf.TestProtos {

  /// <summary>Holder for reflection information generated from unittest_import_proto3.proto</summary>
  public static partial class UnittestImportProto3Reflection {

    #region Descriptor
    /// <summary>File descriptor for unittest_import_proto3.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static UnittestImportProto3Reflection() {
      byte[] descriptorData = 
          new byte[] { 
              0x0a, 0x1c, 0x75, 0x6e, 0x69, 0x74, 0x74, 0x65, 0x73, 0x74, 
              0x5f, 0x69, 0x6d, 0x70, 0x6f, 0x72, 0x74, 0x5f, 0x70, 0x72, 
              0x6f, 0x74, 0x6f, 0x33, 0x2e, 0x70, 0x72, 0x6f, 0x74, 0x6f, 
              0x12, 0x18, 0x70, 0x72, 0x6f, 0x74, 0x6f, 0x62, 0x75, 0x66, 
              0x5f, 0x75, 0x6e, 0x69, 0x74, 0x74, 0x65, 0x73, 0x74, 0x5f, 
              0x69, 0x6d, 0x70, 0x6f, 0x72, 0x74, 0x1a, 0x23, 0x75, 0x6e, 
              0x69, 0x74, 0x74, 0x65, 0x73, 0x74, 0x5f, 0x69, 0x6d, 0x70, 
              0x6f, 0x72, 0x74, 0x5f, 0x70, 0x75, 0x62, 0x6c, 0x69, 0x63, 
              0x5f, 0x70, 0x72, 0x6f, 0x74, 0x6f, 0x33, 0x2e, 0x70, 0x72, 
              0x6f, 0x74, 0x6f, 0x22, 0x1a, 0x0a, 0x0d, 0x49, 0x6d, 0x70, 
              0x6f, 0x72, 0x74, 0x4d, 0x65, 0x73, 0x73, 0x61, 0x67, 0x65, 
              0x12, 0x09, 0x0a, 0x01, 0x64, 0x18, 0x01, 0x20, 0x01, 0x28, 
              0x05, 0x2a, 0x59, 0x0a, 0x0a, 0x49, 0x6d, 0x70, 0x6f, 0x72, 
              0x74, 0x45, 0x6e, 0x75, 0x6d, 0x12, 0x1b, 0x0a, 0x17, 0x49, 
              0x4d, 0x50, 0x4f, 0x52, 0x54, 0x5f, 0x45, 0x4e, 0x55, 0x4d, 
              0x5f, 0x55, 0x4e, 0x53, 0x50, 0x45, 0x43, 0x49, 0x46, 0x49, 
              0x45, 0x44, 0x10, 0x00, 0x12, 0x0e, 0x0a, 0x0a, 0x49, 0x4d, 
              0x50, 0x4f, 0x52, 0x54, 0x5f, 0x46, 0x4f, 0x4f, 0x10, 0x07, 
              0x12, 0x0e, 0x0a, 0x0a, 0x49, 0x4d, 0x50, 0x4f, 0x52, 0x54, 
              0x5f, 0x42, 0x41, 0x52, 0x10, 0x08, 0x12, 0x0e, 0x0a, 0x0a, 
              0x49, 0x4d, 0x50, 0x4f, 0x52, 0x54, 0x5f, 0x42, 0x41, 0x5a, 
              0x10, 0x09, 0x42, 0x1d, 0xaa, 0x02, 0x1a, 0x47, 0x6f, 0x6f, 
              0x67, 0x6c, 0x65, 0x2e, 0x50, 0x72, 0x6f, 0x74, 0x6f, 0x62, 
              0x75, 0x66, 0x2e, 0x54, 0x65, 0x73, 0x74, 0x50, 0x72, 0x6f, 
              0x74, 0x6f, 0x73, 0x50, 0x00, 0x62, 0x06, 0x70, 0x72, 0x6f, 
              0x74, 0x6f, 0x33, };
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.TestProtos.UnittestImportPublicProto3Reflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::Google.Protobuf.TestProtos.ImportEnum), }, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Google.Protobuf.TestProtos.ImportMessage), global::Google.Protobuf.TestProtos.ImportMessage.Parser, new[]{ "D" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Enums
  public enum ImportEnum {
    [pbr::OriginalName("IMPORT_ENUM_UNSPECIFIED")] Unspecified = 0,
    [pbr::OriginalName("IMPORT_FOO")] ImportFoo = 7,
    [pbr::OriginalName("IMPORT_BAR")] ImportBar = 8,
    [pbr::OriginalName("IMPORT_BAZ")] ImportBaz = 9,
  }

  #endregion

  #region Messages
  public sealed partial class ImportMessage : pb::IMessage<ImportMessage> {
    private static readonly pb::MessageParser<ImportMessage> _parser = new pb::MessageParser<ImportMessage>(() => new ImportMessage());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ImportMessage> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Google.Protobuf.TestProtos.UnittestImportProto3Reflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ImportMessage() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ImportMessage(ImportMessage other) : this() {
      d_ = other.d_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ImportMessage Clone() {
      return new ImportMessage(this);
    }

    /// <summary>Field number for the "d" field.</summary>
    public const int DFieldNumber = 1;
    private int d_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int D {
      get { return d_; }
      set {
        d_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as ImportMessage);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(ImportMessage other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (D != other.D) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (D != 0) hash ^= D.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (D != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(D);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (D != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(D);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(ImportMessage other) {
      if (other == null) {
        return;
      }
      if (other.D != 0) {
        D = other.D;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            if (!pb::UnknownFieldSet.MergeFieldFrom(ref _unknownFields, input)) {
              return;
            }
            break;
          case 8: {
            D = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
