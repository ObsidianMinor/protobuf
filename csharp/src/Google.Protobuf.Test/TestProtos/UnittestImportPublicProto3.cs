// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: unittest_import_public_proto3.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Google.Protobuf.TestProtos {

  /// <summary>Holder for reflection information generated from unittest_import_public_proto3.proto</summary>
  public static partial class UnittestImportPublicProto3Reflection {

    #region Descriptor
    /// <summary>File descriptor for unittest_import_public_proto3.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static UnittestImportPublicProto3Reflection() {
      byte[] descriptorData = 
          new byte[] { 
              0x0a, 0x23, 0x75, 0x6e, 0x69, 0x74, 0x74, 0x65, 0x73, 0x74, 
              0x5f, 0x69, 0x6d, 0x70, 0x6f, 0x72, 0x74, 0x5f, 0x70, 0x75, 
              0x62, 0x6c, 0x69, 0x63, 0x5f, 0x70, 0x72, 0x6f, 0x74, 0x6f, 
              0x33, 0x2e, 0x70, 0x72, 0x6f, 0x74, 0x6f, 0x12, 0x18, 0x70, 
              0x72, 0x6f, 0x74, 0x6f, 0x62, 0x75, 0x66, 0x5f, 0x75, 0x6e, 
              0x69, 0x74, 0x74, 0x65, 0x73, 0x74, 0x5f, 0x69, 0x6d, 0x70, 
              0x6f, 0x72, 0x74, 0x22, 0x20, 0x0a, 0x13, 0x50, 0x75, 0x62, 
              0x6c, 0x69, 0x63, 0x49, 0x6d, 0x70, 0x6f, 0x72, 0x74, 0x4d, 
              0x65, 0x73, 0x73, 0x61, 0x67, 0x65, 0x12, 0x09, 0x0a, 0x01, 
              0x65, 0x18, 0x01, 0x20, 0x01, 0x28, 0x05, 0x42, 0x1d, 0xaa, 
              0x02, 0x1a, 0x47, 0x6f, 0x6f, 0x67, 0x6c, 0x65, 0x2e, 0x50, 
              0x72, 0x6f, 0x74, 0x6f, 0x62, 0x75, 0x66, 0x2e, 0x54, 0x65, 
              0x73, 0x74, 0x50, 0x72, 0x6f, 0x74, 0x6f, 0x73, 0x62, 0x06, 
              0x70, 0x72, 0x6f, 0x74, 0x6f, 0x33, };
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Google.Protobuf.TestProtos.PublicImportMessage), global::Google.Protobuf.TestProtos.PublicImportMessage.Parser, new[]{ "E" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class PublicImportMessage : pb::IMessage<PublicImportMessage> {
    private static readonly pb::MessageParser<PublicImportMessage> _parser = new pb::MessageParser<PublicImportMessage>(() => new PublicImportMessage());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<PublicImportMessage> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Google.Protobuf.TestProtos.UnittestImportPublicProto3Reflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PublicImportMessage() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PublicImportMessage(PublicImportMessage other) : this() {
      e_ = other.e_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PublicImportMessage Clone() {
      return new PublicImportMessage(this);
    }

    /// <summary>Field number for the "e" field.</summary>
    public const int EFieldNumber = 1;
    private int e_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int E {
      get { return e_; }
      set {
        e_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as PublicImportMessage);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(PublicImportMessage other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (E != other.E) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (E != 0) hash ^= E.GetHashCode();
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
      if (E != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(E);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (E != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(E);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(PublicImportMessage other) {
      if (other == null) {
        return;
      }
      if (other.E != 0) {
        E = other.E;
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
            E = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
