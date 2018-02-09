// Protocol Buffers - Google's data interchange format
// Copyright 2008 Google Inc.  All rights reserved.
// https://developers.google.com/protocol-buffers/
//
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are
// met:
//
//     * Redistributions of source code must retain the above copyright
// notice, this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above
// copyright notice, this list of conditions and the following disclaimer
// in the documentation and/or other materials provided with the
// distribution.
//     * Neither the name of Google Inc. nor the names of its
// contributors may be used to endorse or promote products derived from
// this software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
// A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT
// OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
// SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
// LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
// THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
// OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

#include <google/protobuf/descriptor.h>
#include <google/protobuf/descriptor.pb.h>
#include <google/protobuf/io/printer.h>
#include <google/protobuf/wire_format.h>

#include <google/protobuf/compiler/csharp/csharp_helpers.h>
#include <google/protobuf/compiler/csharp/csharp_names.h>
#include <google/protobuf/compiler/csharp/csharp_extension.h>

namespace google {
namespace protobuf {
namespace compiler {
namespace csharp {

ExtensionGenerator::ExtensionGenerator(const FieldDescriptor* descriptor,
                                                 const Options* options)
    : SourceGeneratorBase(descriptor->file(), options),
      descriptor_(descriptor) {
}

ExtensionGenerator::~ExtensionGenerator() {

}

void ExtensionGenerator::Generate(io::Printer* printer) {
  printer->Print(
    "$access_level$ static readonly pb::Extension<$extended_type$, $type$> $property_name$ =\n"
    "  new pb::Extension<$extended_type$, $type$>($tag$, $default_value$);\n",
    "access_level", class_access_level(),
    "extended_type", extendee_type_name(),
    "type", GetTypeName(descriptor_),
    "tag", SimpleItoa(internal::WireFormat::MakeTag(descriptor_)),
    "property_name", GetPropertyName(descriptor_),
    "default_value", GetDefaultValue(descriptor_));
}

std::string ExtensionGenerator::extendee_type_name() {
  return extendee_type_name(descriptor_);
}

std::string ExtensionGenerator::extendee_type_name(const FieldDescriptor* descriptor) {
  return GetClassName(descriptor->containing_type());
}

}  // namespace csharp
}  // namespace compiler
}  // namespace protobuf
}  // namespace google
